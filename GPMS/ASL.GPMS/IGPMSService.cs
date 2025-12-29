using Entities.GPMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ASL.GPMS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGPMSService" in both code and config file together.
    [ServiceContract]
    public interface IGPMSService
    {

        [OperationContract]
        FetchDto SkipNGetN_OfCustomerDataWithSearch(int pCompanyID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo);
        [OperationContract]
        FetchDto SkipNGetN_OfStyleDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo);
         [OperationContract]
        FetchDto SkipNGetN_OfSizeDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo);
         [OperationContract]
        FetchDto SkipNGetN_OfColorDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo);

        #region Catalog Operations

        #region Carton
        [OperationContract]
        CatalogDto AddCarton(CartonInfoBo pCartonInfoBo);

        [OperationContract]
        CatalogDto UpdateCarton(CartonInfoBo pCartonInfoBo);

        [OperationContract]
        CatalogDto GetCartonById(int pCartonId);

        [OperationContract]
        CatalogDto GetCartonByCode(string pCartonCode);

        [OperationContract]
        CatalogDto GetAllCartons(bool? pIsActive);
        #endregion

        #region Color
        [OperationContract]
        CatalogDto AddColor(ColorInfoBo pColorInfoBo);

        [OperationContract]
        CatalogDto UpdateColor(ColorInfoBo pColorInfoBo);

        [OperationContract]
        CatalogDto GetColorById(int pColorId);

        [OperationContract]
        CatalogDto GetColorByCode(string pColorCode);

        [OperationContract]
        CatalogDto GetAllColors(bool? pIsActive);
        #endregion

        #region Customer
        [OperationContract]
        CatalogDto AddCustomer(CustomerInfoBo pCustomerInfoBo);

        [OperationContract]
        CatalogDto UpdateCustomer(CustomerInfoBo pCustomerInfoBo);

        [OperationContract]
        CatalogDto GetCustomerById(int pCustomerId);

        [OperationContract]
        CatalogDto GetCustomerByCode(string pCustomerCode);

        [OperationContract]
        CatalogDto GetAllCustomers(bool? pIsActive);
        #endregion

        #region PaymentMode
        [OperationContract]
        CatalogDto AddPaymentMode(PaymentModeInfoBo pPaymentModeInfoBo);

        [OperationContract]
        CatalogDto UpdatePaymentMode(PaymentModeInfoBo pPaymentModeInfoBo);

        [OperationContract]
        CatalogDto GetPaymentModeById(int pPaymentModeId);

        [OperationContract]
        CatalogDto GetPaymentModeByCode(string pPaymentModeCode);

        [OperationContract]
        CatalogDto GetAllPaymentModes(bool? pIsActive);
        #endregion

        #region Size
        [OperationContract]
        CatalogDto AddSize(SizeInfoBo pSizeInfoBo);

        [OperationContract]
        CatalogDto UpdateSize(SizeInfoBo pSizeInfoBo);

        [OperationContract]
        CatalogDto GetSizeById(int pSizeId);

        [OperationContract]
        CatalogDto GetSizeByCode(string pSizeCode);

        [OperationContract]
        CatalogDto GetAllSizes(bool? pIsActive);
        #endregion

        #region Style
        [OperationContract]
        CatalogDto AddStyle(StyleInfoBo pStyleInfoBo);

        [OperationContract]
        CatalogDto UpdateStyle(StyleInfoBo pStyleInfoBo);

        [OperationContract]
        CatalogDto GetStyleById(int pStyleId);

        [OperationContract]
        CatalogDto GetStyleByCode(string pStyleCode);

        [OperationContract]
        CatalogDto GetAllStyles(bool? pIsActive);
        #endregion

        #region Term
        [OperationContract]
        CatalogDto AddTerm(TermInfoBo pTermInfoBo);

        [OperationContract]
        CatalogDto UpdateTerm(TermInfoBo pTermInfoBo);

        [OperationContract]
        CatalogDto GetTermById(int pTermId);

        [OperationContract]
        CatalogDto GetTermByCode(string pTermCode);

        [OperationContract]
        CatalogDto GetAllTerms(bool? pIsActive);
        #endregion

        #region POType
        [OperationContract]
        CatalogDto GetPOTypeById(int pPOTypeId);

        [OperationContract]
        CatalogDto GetPOTypeByCode(string pPOTypeCode);

        [OperationContract]
        CatalogDto GetAllPOTypes(bool? pIsActive);
        #endregion

        #region POLevel
        [OperationContract]
        CatalogDto GetPOLevelById(int pPOLevelId);

        [OperationContract]
        CatalogDto GetPOLevelByCode(string pPOLevelCode);

        [OperationContract]
        CatalogDto GetAllPOLevels(bool? pIsActive);
        #endregion

        #region POForm
        [OperationContract]
        CatalogDto GetPOFormById(int pPOFormId);

        [OperationContract]
        CatalogDto GetPOFormByCode(string pPOFormCode);

        [OperationContract]
        CatalogDto GetAllPOForms(bool? pIsActive);
        #endregion

        #region PackingType
        [OperationContract]
        CatalogDto GetPackingTypeById(int pPackingTypeId);

        [OperationContract]
        CatalogDto GetPackingTypeByCode(string pPackingTypeCode);

        [OperationContract]
        CatalogDto GetAllPackingTypes(bool? pIsActive);
        #endregion

        #region ShipmentTerm
        [OperationContract]
        CatalogDto GetShipmentTermById(int pShipmentTermId);

        [OperationContract]
        CatalogDto GetShipmentTermByCode(string pShipmentTermCode);

        [OperationContract]
        CatalogDto GetAllShipmentTerms(bool? pIsActive);
        #endregion

        #endregion

        #region Order Operations

        #region POM
        [OperationContract]
        OrderDto AddPOM(POMBo POMBo);

        [OperationContract]
        OrderDto UpdatePOM(POMBo POMBo);

        [OperationContract]
        OrderDto GetPOMById(int pPOMId);

        [OperationContract]
        OrderDto GetPOByPONo(string pPONo);
        #endregion

        #region POD
        [OperationContract]
        OrderDto AddPOD(PODBo PODBo);

        [OperationContract]
        OrderDto UpdatePOD(PODBo PODBo);

        [OperationContract]
        OrderDto GetPODById(int pPODId);
        #endregion

        #region POSizeD
        [OperationContract]
        OrderDto AddPOSizeD(POSizeDBo POSizeDBo);

        [OperationContract]
        OrderDto UpdatePOSizeD(POSizeDBo POSizeDBo);

        [OperationContract]
        OrderDto GetPOSizeDById(int pPOSizeDId);
        #endregion

        #endregion

    }



}
