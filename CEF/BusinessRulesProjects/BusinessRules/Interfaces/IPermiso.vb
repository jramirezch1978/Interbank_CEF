'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:15/08/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IPermiso
        Function leer(ByVal pshoCodPermiso As Short) As BusinessEntity.Permiso
        Function leerPermisoPerfil(ByVal pshoCodPermiso As Short, ByVal pshoCodPerfil As Short) As BusinessEntity.PermisoPerfil
    End Interface

End Namespace

