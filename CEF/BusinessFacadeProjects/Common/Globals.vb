'*************************************************************
'Proposito: Tipos y Constantes Globales de CEF
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Globalization
Imports System.Xml.Serialization

Namespace CEF.Common

    Public NotInheritable Class Globals

        's23006
        Public Enum ecEstadoCreacionProyeccion
            NUEVO = 0
            EDITAR = 1
            ELIMINAR = 2
        End Enum

        Public Enum ecUnidad
            <XmlEnum("1")> _
            UND = 1
            <XmlEnum("2")> _
            MILES = 2
            <XmlEnum("3")> _
            MILLONES = 3
        End Enum
        's23006

        <Serializable()> _
        Public Enum ecMoneda
            <XmlEnum("1")> _
            SOLES = 1
            <XmlEnum("2")> _
            DOLARES = 2
            <XmlEnum("3")> _
            EUROS = 3
        End Enum

        Public Enum ecTipoDato
            CARACTER = 67
            NUMERICO = 78
            FECHA = 68
        End Enum

        Public Enum ecMntPage
            NOACCION = 0
            AGREGAR = 1
            MODIFICAR = 2
            ELIMINAR = 3
            GRABAR = 4
            BUSCAR = 5
            ORDENAR = 6
            REGRESAR = 7
            IMPORTAR = 8
            EXPORTAR = 9
            IMPRIMIR = 10
            REFRESCAR = 11
        End Enum

        Public Enum ecTablaGeneral
            TABLA = 0
            ESTADO_METODIZADO = 1
            ESTADO_PERIODO = 2
            ESTADO_AUDITOR = 3
            ESTADO_TIPO_EEFF = 4
            MONEDA = 5
            UNIDAD_IMPORTE = 6
            ESTADO_PARAMETRO = 7
            ESTADO_GENERAL = 8
            TIPO_DOCUMENTO = 9
            TIPO_OPERANDO = 10
            ESTADO_EEFF = 11
            ESTADO_ANALISIS = 12
            ESTADO_OPERADOR = 13
            ESTADO_CUENTA = 14
            ESTADO_CUENTA_ANALISIS = 15
            TIPO_CUENTA = 16
            ESTADO_TIPOCAMBIO = 17
            MES = 18
            TIPO_FORMULA = 19
            ESTADO_FORMATO = 20
            ESTADO_FORMULA = 21
            ESTADO_SUPUESTO = 22
            ESTADO_USUARIO = 23
            TIPO_DOC_CLIENTE = 24
            ' 16/01/2014 : JAVILA (CGI)
            SEGMENTO = 55
            ' 16/01/2014 : JAVILA (CGI)
            TIPO_DOC_CLIENTE_BPE = 56
            ' 30/01/2014 : JAVILA (CGI)
            TIPO_BANCA = 54
            FRECUENCIA_COVENANT = 58 'XT8633
            TIPO_DOC_CLIENTE_RM = 59 'XT8633 03092019
            MONEDAEMPRELACIONADA = 61 'XT-9104
            MONEDAIMPEMPRELACIONADA = 62 'XT-9104
        End Enum

        Public Enum ecTipoDocumentoCliente
            Sin_Documento = 0
            RUC = 1
            DNI = 2
            CARNET_EXTRANJERÍA = 3
            EMPRESA_RELACIONADA = 4
        End Enum

        Public Enum ecTipoDocumento
            CODIGO_UNICO = 1
            RUC = 2
        End Enum

        Public Enum ecEstadoMetodizado
            INCOMPLETO_NEGOCIO = 1
            PENDIENTE = 2
            INCOMPLETO_RIESGO = 3
            VALIDADO = 4
        End Enum

        Public Enum ecEstadoCorridaMetodizado
            ACTIVO = 1
            INACTIVO = 2
        End Enum

        Public Enum ecEstadoPeriodoCorrida
            ACTIVO = 1
            INACTIVO = 2
        End Enum

        <Serializable()> _
        Public Enum ecEstadoPeriodo
            <XmlEnum("1")> _
            PENDIENTE = 1
            <XmlEnum("2")> _
            VALIDADO = 2
        End Enum

        Public Enum ecTipoSupuesto
            OPTIMISTA = 1
            PESIMISTA = 2
            PROBABLE = 3
        End Enum

        Public Enum ecTipoPeriodoProyectado As Byte
            HISTORICO = 1
            PROYECTADO = 2
        End Enum

        Public Enum ecPerfil
            ADMINISTRADOR = 1
            ANALISTA_RIESGO = 2
            EJECUTIVO_NEGOCIO = 3
            EJECUTIVO_PRODUCTO = 4
            FUNCIONARIO_INGRESO = 5
            FUNCIONARIO_CONSULTA = 6
            ANALISTA_RIESGO_BPE = 7
            EJECUTIVO_NEGOCIO_BPE = 8
        End Enum

        Public Enum ecTabMntMetodizado
            PERIODO = 1
            RECONCILIACION = 2
        End Enum

        Public Enum ecReporte
            RankingEmpresasporCIIU = 1
            RankingEmpresasporGrupoEconomico = 2
            AnalisisFinanciero = 3
            CruceRCD = 4
            InformeSBS = 5
            DescargaData = 6
        End Enum

        Public Enum ecTipoBanca
            BancaEmpresa = 1
            BancaPequenaEmpresa = 2
        End Enum

        'I-XT9104 - 18/02/2020
        Public Enum ecTipoCuenta
            CUENTA_LIBRE = 5
        End Enum
        'F-XT9104 - 18/02/2020

        Public Const ccArchivoDataConfig As String = "cefDataConfig.xml"

        Public Const ccTOOLTIPTEXT_AGREGAR As String = "Click para agregar nuevos registros"
        Public Const ccTOOLTIPTEXT_MODIFICAR As String = "Click para modificar el registro"
        Public Const ccTOOLTIPTEXT_ELIMINAR As String = "Click para eliminar los registro marcados"
        Public Const ccTOOLTIPTEXT_GRABAR As String = "Click para grabar el registro"
        Public Const ccTOOLTIPTEXT_BUSCAR As String = "Click para buscar"
        Public Const ccTOOLTIPTEXT_ORDENAR As String = "Click para ordenar la lista"
        Public Const ccTOOLTIPTEXT_REGRESAR As String = "Click para regresar"
        Public Const ccTOOLTIPTEXT_IMPORTAR As String = "Click para importar"
        Public Const ccTOOLTIPTEXT_EXPORTAR As String = "Click para exportar"
        Public Const ccTOOLTIPTEXT_IMPRIMIR As String = "Click para imprimir"

        Public Const ccALERTA_AGREGAR As String = "¿Seguro de agregar el registro?"
        Public Const ccALERTA_AGREGAR_EXISTENTE As String = "¿Seguro de agregar el registro en base al existente?"
        Public Const ccALERTA_MODIFICAR As String = "¿Seguro de modificar el registro?"
        Public Const ccALERTA_ELIMINAR As String = "¿Seguro de eliminar el registro?"
        Public Const ccALERTA_GRABAR As String = "¿Seguro de grabar el registro?"

        Public Const ccALERTA_EXITO_AGREGAR As String = "Se agrego con exito el registro"
        Public Const ccALERTA_EXITO_MODIFICAR As String = "Se modifico con exito el registro"
        Public Const ccALERTA_EXITO_ELIMINAR As String = "Se elimino con exito el registro"
        Public Const ccALERTA_EXITO_IMPORTAR As String = "Se importo con exito los registros"
        Public Const ccALERTA_EXITO_EXPORTAR As String = "Se exporto con exito los registros"

        Public Const ccALERTA_ERROR_AGREGAR As String = "Error al agregar el registro"
        Public Const ccALERTA_ERROR_MODIFICAR As String = "Error al modificar el registro"
        Public Const ccALERTA_ERROR_ELIMINAR As String = "Error al eliminar el registro"
        Public Const ccALERTA_ERROR_IMPORTAR As String = "Error al importar los registros"
        Public Const ccALERTA_ERROR_BUSCAR As String = "Error al buscar el registro"
        Public Const ccALERTA_ERROR_CUCLIENTE_RUC_DUPLICADO As String = "No se puede Grabar el Metodizado:\n\nCódigo Único y/o RUC ingresado ya Existe\n\nVerificar con el botón Buscar"
        Public Const ccALERTA_REGISTRO_NO_ENCONTRADO As String = "No se encontro el registro"
        Public Const ccALERTA_BUSQUEDA_RESULTADO_CERO As String = "No se encontro registro(s) según los criterios ingresados"
        Public Const ccALERTA_SELECCIONAR_TIPO_DOCUMENTO As String = "Debe seleccionar un tipo de documento"
        Public Const ccALERTA_INGRESAR_DOCUMENTO As String = "Debe ingresar un número de documento"

        Public Const ccALERTA_BLOQUEO_AGREGAR_PERIODO As String = "Acción bloqueada:\nPrimero debe grabar los datos de cabecera del metodizado"
        Public Const ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO As String = "Acción bloqueada:\nNo existe periodos filtrados"
        Public Const ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO_COV As String = "Acción bloqueada:\nNo existe periodos de cierre seleccionados"
        Public Const ccALERTA_BLOQUEO_IMPRIMIR_NO_EXISTE_PERIODO As String = "Acción bloqueada:\nEl metodizado no presenta periodos para su impresión"
        Public Const ccALERTA_BLOQUEO_EXPORTAR_NO_EXISTE_PERIODO As String = "Acción bloqueada:\nEl metodizado no presenta periodos para exportar"
        Public Const ccALERTA_ERROR_PERIODO_DUPLICADO As String = "Error\nNo se puede duplicar periodos con la misma fecha y tipo de EEFF"
        Public Const ccALERTA_ERROR_AGREGAR_PERIODO_TIPOCAMBIO As String = "Error\nNo existe tipo de cambio registrado para ese periodo"

        Public Const ccALERTA_GRABAR_RECONCILIACION As String = "¿Seguro de grabar los periodos ingresados?"
        Public Const ccALERTA_VALIDA_RECONCILIACION As String = "¿Seguro de Validar los periodos ingresados?"
        Public Const ccALERTA_ENVIA_RECONCILIACION As String = "¿Seguro de Enviar a Admisión Riesgos los periodos ingresados?"
        Public Const ccALERTA_EXITO_GRABAR_RECONCILIACION As String = "Se grabo correctamente la reconciliación del metodizado"
        Public Const ccALERTA_ERROR_GRABAR_RECONCILIACION As String = "Error al intentar reconciliaciliar el metodizado"
        Public Const ccALERTA_ERROR_CUADRE_EEFF As String = "Error en el cuadre de los Estado Financiero. Favor verificar las siguientes cuentas:\nCUADRE (ACTIVO - PASIVO Y PATRIMONIO) = 0\nCUADRE PATRIMONIO FINAL - SUBTOTAL = 0\nDEPRECIACION > 0\nINVERSION >= 0\nEXISTA INFORMACIÓN RIESGO CAMBIARIO entre 0 y 100"

        Public Const ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO As String = "Acción bloqueada:\nPrimero debe grabar los datos de cabecera del supuesto"
        Public Const ccALERTA_GRABAR_SUPUESTO As String = "¿Seguro de grabar los supuestos proyectados?"
        Public Const ccALERTA_SUPUESTO_HISTORICO_SIN_PERIODO_ANTERIOR As String = "Error\nNo existe periodo anterior para analizar los importes historicos"
        Public Const ccALERTA_SUPUESTO_HISTORICO_SIN_CIERRE As String = "Error\nPeriodo Histórico debe ser Cierre de Año: 31/12/YYYY"
        Public Const ccALERTA_BLOQUEO_IMPRIMIR_NO_EXISTE_SUPUESTO As String = "Acción bloqueada:\nNo existe supuesto proyectado para su impresión"
        Public Const ccALERTA_BLOQUEO_EXPORTAR_NO_EXISTE_SUPUESTO As String = "Acción bloqueada:\nNo existe supuesto proyectado para exportar"
        Public Const ccALERTA_ERROR_SUPUESTO_DUPLICADO As String = "Error\nNo se puede duplicar supuesto ó escenario con la misma descripción"

        Public Const ccALERTA_BLOQUEO_CARTERA_USUARIO As String = "Acción bloqueada:\nPrimero debe grabar los datos del usuario.\nEl usuario debera tener un perfil con autorización de cartera"
        Public Const ccALERTA_ERROR_AGREGAR_USUARIO As String = "Error al agregar registro: Registro de Usuario Existe"

        Public Const ccALERTA_EXITO_CARGA_ARCHIVO_RCD As String = "El archivo RCD ha sido cargado con éxito"
        Public Const ccALERTA_ERROR_SELECCIONAR_ARCHIVO_RCD As String = "Seleccione el archivo RCD a cargar"
        Public Const ccALERTA_ERROR_CARGA_ARCHIVO_RCD As String = "Error en la carga del archivo RCD"

        Public Const ccALERTA_OPERACION_EN_PROCESO As String = "Existe una operación en proceso...\nPara continuar de click en el boton Aceptar"

        Public Const ccMSG_ERROR_CADENA As String = "Tamaño de cadena mayor a la longitud especificada"
        'ADD XT8633
        Public Const ccALERTA_NO_FRECUENCIA_COVENANT As String = "Advertencia...\nSeleccionar una frecuencia de medición de covenants - Guardar nuevamente la cabecera, para el correcto cálculo de covenants."

        'ADD ADR 14/01/2019 COVENANTS
        Public Const ecCampo1LibreCovenant As String = "Campo1"
        Public Const ecCampo2LibreCovenant As String = "Campo2"
        Public Const ecCampo3LibreCovenant As String = "Campo3"
        Public Const ecCampo4LibreCovenant As String = "Campo4"
        Public Const ecCampo5LibreCovenant As String = "Campo5"

        'I-XT9104 - 18/02/2020
        Public Const ccALERTA_VALIDACION_CAMPOLIBRE As String = "Debe ingresar valor en los campos libres"
        'F-XT9104 - 18/02/2020

        Sub New()
            'Nada
        End Sub

    End Class

End Namespace