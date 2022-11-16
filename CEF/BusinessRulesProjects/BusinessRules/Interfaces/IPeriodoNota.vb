Imports System
Imports System.Data
Imports CEF.BusinessEntity
Imports System.Collections


Namespace CEF.BusinessRules

    Public Interface IPeriodoNota

        Function listarBD(ByVal pstrCodMetodizado As Int32, ByVal pstrArrayPeriodoFiltrado As String, ByVal pintCodigoCuenta As Int16) As ArrayList
        Function guardar(ByVal ListaNotas As ArrayList) As Int16
        Function verificarExistenciaNota(ByVal pstrCodMetodizado As Int32, ByVal pstrArrayPeriodoFiltrado As String, ByVal pintCodigoCuenta As Int16) As Int16

    End Interface

End Namespace


