'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro J�come
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Namespace CEF.WebUI

    Partial Class MaskWindowDialogo
        Inherits System.Web.UI.Page

#Region " C�digo generado por el Dise�ador de Web Forms "

        'El Dise�ador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
            'No la modifique con el editor de c�digo.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            cargaDatos()
        End Sub

        Private Sub cargaDatos()
            Dim strRawUrl As String = Request.RawUrl()

            Const ccSRC As String = "pvSrc"
            Const ccWIDTH As String = "pvWidth"
            Const ccHEIGHT As String = "pvHeight"

            Dim intPosIni As Integer
            Dim intPosFin As Integer

            Dim intPosSrc As Integer = strRawUrl.IndexOf("pvSrc")
            Dim intPosWidth As Integer = strRawUrl.IndexOf("pvWidth")
            Dim intPosHeight As Integer = strRawUrl.IndexOf("pvHeight")

            intPosIni = intPosSrc + (ccSRC.Length + 1)
            intPosFin = intPosWidth - 1
            Dim strSrc As String = strRawUrl.Substring(intPosIni, intPosFin - intPosIni)

            intPosIni = intPosWidth + (ccWIDTH.Length + 1)
            intPosFin = intPosHeight - 1
            Dim strWidth As String = strRawUrl.Substring(intPosIni, intPosFin - intPosIni)

            intPosIni = intPosHeight + (ccHEIGHT.Length + 1)
            Dim strHeight As String = strRawUrl.Substring(intPosIni)

            ifrMaskVtnDlg.Attributes("src") = strSrc
            ifrMaskVtnDlg.Attributes("width") = Convert.ToString(Convert.ToInt32(strWidth) - 4)
            ifrMaskVtnDlg.Attributes("height") = Convert.ToString(Convert.ToInt32(strHeight) - 24)
        End Sub

    End Class

End Namespace