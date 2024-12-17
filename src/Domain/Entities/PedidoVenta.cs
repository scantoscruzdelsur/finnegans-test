namespace Finnegans.Domain.Entities;

public class PedidoVenta
{
    public List<Concepto> Conceptos { get; set; } = [];
    public int? Usr_estadopedido { get; set; }
    public bool USR_PlanillaCerrada { get; set; }
    public string? ListaPrecioCodigo { get; set; }
    public string? WorkflowCodigo { get; set; }
    public string? USR_ClienteCodigoPostal { get; set; }
    public string? Descripcion { get; set; }
    public string? USR_DestinatarioCodigoPostal { get; set; }
    public bool USR_aCuentayOrdenTerceros { get; set; }
    public bool USR_EsRetiro { get; set; }
    public string? USR_DestinatarioNombre { get; set; }
    public string? USR_UnidadTarifada { get; set; }
    public bool USR_EsToxico { get; set; }
    public string? USR_OrdenServicioRetiro { get; set; }
    public string? CDS_Ensobrado { get; set; }
    public string? USR_NumeroDeEnvio { get; set; }
    public bool USR_ImpresoFNN { get; set; }
    public string? ProvinciaDestinoCodigo { get; set; }
    public string? TipoEnvioECommerce { get; set; }
    public int NumeroInterno { get; set; }
    public string? USR_ClienteNombre { get; set; }
    public string? USR_SucursalOrigen { get; set; }
    public bool USR_EsCadenaFrio { get; set; }
    public string? USR_NroRendiUNIX { get; set; }
    public decimal USR_MetrosCubicos { get; set; }
    public string? CAEFechaVto { get; set; }
    public string? USR_ClienteContraReembolsoID { get; set; }
    public string? NumeroComprobante { get; set; }
    public string? Fecha { get; set; }
    public string? Cliente { get; set; }
    public string? TransaccionTipoCodigo { get; set; }
    public string? USR_SucursalCliente { get; set; }
    public string? USR_CuerpoFactura { get; set; }
    public string? OrigenECommerce { get; set; }
    public List<Cotizacione> Cotizaciones { get; set; } = [];
    public string? USR_FechaEntrega { get; set; }
    public decimal USR_KilosReales { get; set; }
    public string? USR_Maildestinatario { get; set; }
    public string? USR_NroViaje { get; set; }
    public decimal USR_ImporteContraReembolso { get; set; }
    public string? USR_Itinerario { get; set; }
    public string? USR_TipoTarifa { get; set; }
    public string? USR_NroReparto { get; set; }
    public string? USR_RemitenteNombre { get; set; }
    public string? CDS_Facturado { get; set; }
    public string? USR_FechaConforme { get; set; }
    public string? Nombre { get; set; }
    public string? USR_Recorrido { get; set; }
    public bool USR_HabilitaPagoCR { get; set; }
    public string? USR_NumeroGuia { get; set; }
    public decimal USR_KilosFacturados { get; set; }
    public string? ProvinciaOrigenCodigo { get; set; }
    public bool USR_EntregarFechaPactada { get; set; }
    public string? MonedaCodigo { get; set; }
    public List<Item> Items { get; set; } = [];
    public string? USR_URLHistorial { get; set; }
    public string? USR_RemitenteTelefono { get; set; }
    public int Transaccionid { get; set; }

    public string? CAE { get; set; }

    public string? USR_SucursalIDOCAbierta { get; set; }

    public string? USR_ClienteTelefono { get; set; }
    public string? USR_CuentaDelCliente { get; set; }
    public string? USR_ClienteDomicilio { get; set; }

    public string? USR_ClienteLocalidad { get; set; }
    public int USR_CantBultos { get; set; }
    public string? USR_RemitenteCodigoPostal { get; set; }
    public string? USR_RemitenteCUIT { get; set; }
    public bool USR_ImpresoTMS { get; set; }
    public bool USR_CobroContraReembolsoEfectivo { get; set; }
    public int? USR_SolicitanteID { get; set; }
    public bool USR_HabilitaEntrega { get; set; }
    public string? USR_TipoViaje { get; set; }
    public bool USR_EsAereo { get; set; }
    public string? USR_FechaPactada { get; set; }
    public string? USR_DestinatarioCUIT { get; set; }
    public string? USR_Mailremitente { get; set; }
    public decimal USR_AdicionalReceptoria { get; set; }
    public string? USR_SeguroPropio { get; set; }
    public int USR_NroOperador { get; set; }
    public string? IdentificacionExterna { get; set; }
    public string? USR_DestinatarioDomicilio { get; set; }
    public string? USR_ContraReemBolso { get; set; }
    public string? USR_ClaveCliente { get; set; }
    public string? USR_DestinatarioTelefono { get; set; }
    public string? USR_PlanillaDeConforme { get; set; }
    public string? CondicionPagoCodigo { get; set; }
    public string? SucursalID { get; set; }
    public string? EmpresaCodigo { get; set; }
    public string? USR_DestinatarioLocalidad { get; set; }
    public string? TransaccionSubtipoCodigo { get; set; }
    public string? ComprobanteTipoImpositivoCodigo { get; set; }
    public bool USR_EsProvisoria { get; set; }
    public string? VendedorCodigo { get; set; }

    public string? USR_RemitoCliente { get; set; }
    public decimal USR_ValorDeclarado { get; set; }
    public string? USR_RemitoAsoc { get; set; }
    public string? USR_PendienteCodigo { get; set; }
    public bool USR_PlanillaRecibida { get; set; }
    public string? USR_RemitenteDomicilio { get; set; }
    public string? USR_Tipodecarga { get; set; }
    public string? USR_SucursalDestino { get; set; }
    public string? USR_URLDocDigital { get; set; }
    public bool USR_EtiquetaModificada { get; set; }

    public string? CDS_Rendido { get; set; }
    public int USR_CantidadArticulosenBultos { get; set; }
    public string? USR_Codigodezona { get; set; }
    public string? USR_DetalleMercaderia { get; set; }
    public string? USR_RemitenteLocalidad { get; set; }
    public string? Observacion2 { get; set; }
    public string? Observacion1 { get; set; }
    public bool USR_BloqueoEntrega { get; set; }
    public string? vinculacionOrigen { get; set; }
}

public class Concepto
{
    public decimal ConceptoImporteGravado { get; set; }

    public bool ImporteEditables { get; set; }
    public decimal ConceptoImporte { get; set; }
    public string? ConceptoCodigo { get; set; }
}


public class Cotizacione
{
    public string? MonedaID { get; set; }
    public decimal Cotizacion { get; set; }
}

public class Item
{
    public decimal Cantidad2 { get; set; }
    public string? USRNroPlanilla { get; set; }
    public string? USRNroGuia { get; set; }
    public decimal? PrecioBase { get; set; }
    public decimal ImporteImpuestoIncluido { get; set; }
    public decimal Importe { get; set; }
    public decimal? CantidadPresentacion { get; set; }
    public string? PartidaNumero { get; set; }
    public string? ProductoCodigo { get; set; }
    public decimal? Descuento1 { get; set; }
    public string? ProvinciaItemOrigenCodigo { get; set; }
    public string? ProvinciaItemDestinoCodigo { get; set; }
    public string? USRSolicitanteID { get; set; }
    public decimal Cantidad { get; set; }
    public bool IncluyeImpuesto { get; set; }
    public string? DepositoIDDestino { get; set; }
    public string? Descripcion { get; set; }
    public List<DimensionDistribucions> DimensionDistribucion { get; set; } = [];
    public string? USRTransaccionCNID { get; set; }
    public List<PartidaFechaVtos> PartidaFechaVto { get; set; } = [];
    public decimal Precio { get; set; }
    public string? vinculacionOrigen { get; set; }
}

public class PartidaFechaVtos
{
    public string? serialVersionUID { get; set; }
}

public class DimensionDistribucions
{
    public string? tipoCalculo { get; set; }
    public string? distribucionCodigo { get; set; }
    public List<distribucionItem> distribucionItems { get; set; } = [];
    public string? dimensionCodigo { get; set; }
}

public class distribucionItem
{
    public string? codigo { get; set; }
    public decimal? porcentaje { get; set; }
    public decimal? importe { get; set; }
}

public class RespuestaBusquedaNIC
{
    public string? codigo { get; set; }
}
