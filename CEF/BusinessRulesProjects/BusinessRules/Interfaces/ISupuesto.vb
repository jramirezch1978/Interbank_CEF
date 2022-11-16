Imports System
Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface ISupuesto
        Function leer(ByVal pintCodSupuesto As Integer) As BusinessEntity.Supuesto
        Function buscarPorPeriodo(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As DataSet
        Function agregar(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean
        Function modificar(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean
        Function eliminar(ByVal pintCodSupuesto As Integer) As Boolean
        Function agregarSupuestoProyectado(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean
        Function listarPeriodoProyectado(ByVal pintCodSupuesto As Integer) As BusinessEntity.PeriodoProyectadoLst
        Function listarSupuestoProyectado(ByVal pintCodSupuesto As Integer, ByVal pintCodProyectado As Integer) As DataSet
        Function calcularSupuestoHistoricoInicial(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer, ByVal pintCodPeriodoAnterior As Integer) As DataSet
        Function calcularSupuestoProyectadoInicial(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer, ByVal pintCodPeriodoAnterior As Integer, ByVal pbytNumeroProyectado As Byte) As DataSet
        Function filtrarSupuestoProyectado(ByVal pintCodSupuesto As Integer) As DataSet
        Function filtrarFlujoProyectado(ByVal pintCodSupuesto As Integer) As DataSet
    End Interface

End Namespace

