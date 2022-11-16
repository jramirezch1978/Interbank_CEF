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

    Partial Class busGrupoEconomico
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

        Protected Overrides Sub cargarScript()
            MyBase.cargarScript()
            txtCodigo.Attributes.Add("onkeypress", "javascript:txtDescripcion.value='';")
        End Sub

        Protected Overrides Sub inicializarControles()
            Me.Titulo = "Buscar Grupo Económico"
            MyBase.inicializarControles()
        End Sub

        Protected Overrides Sub buscar()
            Dim obrGrupoEconomico As BusinessRules.GrupoEconomico = New BusinessRules.GrupoEconomico
            'MEJORAS CEF ii
            'Me.CampoCodigo = "Codigo"
            Me.CampoCodigo = "CodGrupoEconomico"
            Me.CampoDescripcion = "Nombre"
            If Me.Codigo <> String.Empty Then
                Me.Resultado = obrGrupoEconomico.buscarXCodigo(Me.Codigo)
            ElseIf Me.Descripcion <> String.Empty Then
                Me.Resultado = obrGrupoEconomico.buscarXNombre(Me.Descripcion)
            End If
            obrGrupoEconomico = Nothing
        End Sub

    End Class

End Namespace
