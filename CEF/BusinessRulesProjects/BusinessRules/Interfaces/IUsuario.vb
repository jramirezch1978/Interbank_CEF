'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:14/01/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IUsuario
        Function leer(ByVal pstrCodUsuario As String) As BusinessEntity.Usuario
        Function buscar(ByRef pobeUsuario As BusinessEntity.Usuario) As DataSet
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function agregar(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean
        Function modificar(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean
        Function eliminar(ByVal pstrCodUsuario As String) As Boolean
        Function responsableCarteraUsuario(ByVal pstrCodUsuario As String) As BusinessEntity.Usuario
        Function listarResponsableCarteraUsuario() As DataSet
        Function listarSubordinadoCarteraUsuario(ByVal pstrCodUsuarioResponsable As String) As DataSet
        Function listarUsuarioPorAsignarCarteraUsuario(ByVal pstrCodUsuarioResponsable As String) As DataSet
        Function agregarCarteraUsuario(ByRef pobeUsuario As BusinessEntity.Usuario) As DataSet
        Function eliminarCarteraUsuario(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean
        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        Function listarResponsableCarteraUsuarioBPE() As DataSet
        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        Function listarResponsableCarteraUsuarioNoBPE() As DataSet
    End Interface

End Namespace

