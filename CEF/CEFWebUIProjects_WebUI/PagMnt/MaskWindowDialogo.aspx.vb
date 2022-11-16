'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Namespace CEF.WebUI

    Partial Class MaskWindowDialogo
        Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
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