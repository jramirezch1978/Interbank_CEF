'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro J�come
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

        Protected Overrides Sub cargarScript()
            MyBase.cargarScript()
            txtCodigo.Attributes.Add("onkeypress", "javascript:txtDescripcion.value='';")
        End Sub

        Protected Overrides Sub inicializarControles()
            Me.Titulo = "Buscar Grupo Econ�mico"
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
