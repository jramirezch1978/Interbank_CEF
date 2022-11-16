'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.BusinessRules
Imports CEF.Common
Imports CEF.BusinessEntity

Namespace CEF.WebUI

    Partial Class busCIIU
        Inherits busBase

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

        Protected Overrides Sub inicializarControles()
            Me.Titulo = "Buscar CIIU"
            MyBase.inicializarControles()
        End Sub

        Protected Overrides Sub buscar()
            Dim obrCIIU As BusinessRules.CIIU = New BusinessRules.CIIU
            Me.CampoCodigo = "CodCIIU"
            Me.CampoDescripcion = "Nombre"
            If Me.Codigo <> String.Empty Then
                Me.Resultado = obrCIIU.buscarXCodigo(Me.Codigo)
            ElseIf Me.Descripcion <> String.Empty Then
                Me.Resultado = obrCIIU.buscarXNombre(Me.Descripcion)
            End If
            obrCIIU = Nothing
        End Sub

    End Class

End Namespace
