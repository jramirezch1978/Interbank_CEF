Imports System
Imports System.Collections
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Namespace CEF.WebUI

    Public Class PdfMerge
        Private pbaseFont As BaseFont
        Private penablePagination As Boolean = False
        Private ReadOnly pdocuments As ArrayList 'List(Of PdfReader)
        Private totalPages As Integer

        Public Property BaseFont() As BaseFont
            Get
                Return pbaseFont
            End Get
            Set(ByVal value As BaseFont)
                pbaseFont = value
            End Set
        End Property
        Public Property EnablePagination() As Boolean
            Get
                Return penablePagination
            End Get
            Set(ByVal value As Boolean)
                penablePagination = value
                If value AndAlso pbaseFont Is Nothing Then
                    pbaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
                End If
            End Set
        End Property
        Public ReadOnly Property Documents() As ArrayList
            Get
                Return pdocuments
            End Get
        End Property
        Public Sub AddDocument(ByVal filename As String)
            pdocuments.Add(New PdfReader(filename))
        End Sub
        Public Sub AddDocument(ByVal pdfStream As Stream)
            pdocuments.Add(New PdfReader(pdfStream))
        End Sub
        Public Sub AddDocument(ByVal pdfContents() As Byte)
            pdocuments.Add(New PdfReader(pdfContents))
        End Sub
        Public Sub AddDocument(ByVal pdfDocument As PdfReader)
            pdocuments.Add(pdfDocument)
        End Sub
        Public Sub Merge(ByVal outputFilename As String)
            Merge(New FileStream(outputFilename, FileMode.Create))
        End Sub
        Public Sub Merge(ByVal outputStream As Stream)
            If outputStream Is Nothing OrElse (Not outputStream.CanWrite) Then
                Throw New Exception("OutputStream es nulo o no se puede escribir en éste.")
            End If
            Dim newDocument As Document = Nothing
            Try
                newDocument = New Document(PageSize.A4.Rotate)
                Dim pdfWriter As pdfWriter = pdfWriter.GetInstance(newDocument, outputStream)

                newDocument.Open()
                Dim pdfContentByte As pdfContentByte = pdfWriter.DirectContent

                If EnablePagination Then

                End If

                Dim currentPage As Integer = 1
                For Each pdfReader As pdfReader In Documents
                    For page As Integer = 1 To pdfReader.NumberOfPages
                        newDocument.SetPageSize(pdfReader.GetPageSizeWithRotation(page))
                        newDocument.NewPage()
                        Dim importedPage As PdfImportedPage = pdfWriter.GetImportedPage(pdfReader, page)
                        pdfContentByte.AddTemplate(importedPage, 0, 0)

                        If EnablePagination Then
                            pdfContentByte.BeginText()
                            pdfContentByte.SetFontAndSize(BaseFont, 9)
                            pdfContentByte.ShowTextAligned(pdfContentByte.ALIGN_CENTER, String.Format("{0} de {1}", currentPage, totalPages), 520, 5, 0)
                            currentPage += 1
                            pdfContentByte.EndText()
                        End If
                    Next page
                Next pdfReader

            Finally
                outputStream.Flush()
                If Not newDocument Is Nothing Then
                    newDocument.Close()
                End If
                outputStream.Close()
            End Try
        End Sub
        Public Sub New()
            pdocuments = New ArrayList
        End Sub
    End Class


End Namespace