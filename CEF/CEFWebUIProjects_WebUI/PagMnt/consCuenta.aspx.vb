'*************************************************************
'Proposito:
'Autor: María Laura Santisteban Valdez
'Fecha Creacion: 23/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.Common
Imports CEF.Common.Util
Imports CEF.Common.Globals
Imports CEF.BusinessRules

Namespace CEF.WebUI

    Partial Class consCuenta
        Inherits PageBase

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
            'Introducir aquí el código de usuario para inicializar la página
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        cargaDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargaDatos()
                End If
            End If
        End Sub

        Private Sub cargaDatos()
            'Dim iobjCuenta As BusinessInterface.ICuenta_bk
            'Dim objCuenta As BusinessRules.Cuenta_bk = New BusinessRules.Cuenta_bk

            'iobjCuenta = CType(objCuenta, BusinessInterface.ICuenta_bk)
            'Dim voDataSet As DataSet = iobjCuenta.listar()
            'dgrdCuenta.DataSource = voDataSet
            'dgrdCuenta.DataKeyField = "CodCuenta"
            'dgrdCuenta.DataBind()

            'lblNumReg.Text = voDataSet.Tables(0).Rows.Count.ToString()
            'objCuenta = Nothing
        End Sub

        Private Sub dgrdCuenta_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdCuenta.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"

                'modificar con el campo que identifica eeff
                If Int32.Parse(DataBinder.Eval(e.Item.DataItem, "CodTipoCuenta")) = 1 Then
                    e.Item.BackColor = e.Item.BackColor.FromArgb(224, 220, 220)
                    e.Item.Font.Bold = True
                ElseIf Int32.Parse(DataBinder.Eval(e.Item.DataItem, "CodTipoCuenta")) = 2 Then
                    e.Item.BackColor = e.Item.BackColor.FromArgb(206, 221, 224)
                ElseIf Int32.Parse(DataBinder.Eval(e.Item.DataItem, "CodTipoCuenta")) = 3 Then
                    e.Item.BackColor = e.Item.BackColor.FromArgb(242, 206, 206)
                End If
            End If
        End Sub

    End Class

End Namespace
