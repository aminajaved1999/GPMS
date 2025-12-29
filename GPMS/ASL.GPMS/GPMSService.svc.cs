using BLL.GPMS;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GPMSService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GPMSService.svc or GPMSService.svc.cs at the Solution Explorer and start debugging.
    public class GPMSService : IGPMSService
    {
        #region Fetch Skip N Get N
        public FetchDto SkipNGetN_OfCustomerDataWithSearch(int pCompanyID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            return new FetchManager().SkipNGetN_OfCustomerDataWithSearch(pCompanyID, pIsActive, pSearchTxt, pSkipNo, pTakeNo);
        }
        public FetchDto SkipNGetN_OfStyleDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            return new FetchManager().SkipNGetN_OfStyleDataWithSearch(pCustomerID, pIsActive, pSearchTxt, pSkipNo, pTakeNo);
        }
        public FetchDto SkipNGetN_OfSizeDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            return new FetchManager().SkipNGetN_OfSizeDataWithSearch(pCustomerID, pIsActive, pSearchTxt, pSkipNo, pTakeNo);
        }
        public FetchDto SkipNGetN_OfColorDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            return new FetchManager().SkipNGetN_OfColorDataWithSearch(pCustomerID, pIsActive, pSearchTxt, pSkipNo, pTakeNo);
        }
        #endregion

        #region Catalog

        #region  Carton
        public CatalogDto AddCarton(CartonInfoBo pCartonInfoBo)
        {
            var _cartonInfoManager = new CartonInfoManager();
            return _cartonInfoManager.AddCarton(pCartonInfoBo);
        }

        public CatalogDto UpdateCarton(CartonInfoBo pCartonInfoBo)
        {
            var _cartonInfoManager = new CartonInfoManager();
            return _cartonInfoManager.UpdateCarton(pCartonInfoBo);
        }

        public CatalogDto GetCartonById(int pCartonId)
        {
            var _cartonInfoManager = new CartonInfoManager();
            return _cartonInfoManager.GetCartonById(pCartonId);
        }

        public CatalogDto GetCartonByCode(string pCartonCode)
        {
            var _cartonInfoManager = new CartonInfoManager();
            return _cartonInfoManager.GetCartonByCode(pCartonCode);
        }

        public CatalogDto GetAllCartons(bool? pIsActive)
        {
            var _cartonInfoManager = new CartonInfoManager();
            return _cartonInfoManager.GetAllCartons(pIsActive);
        }
        #endregion Carton

        #region  Color
        public CatalogDto AddColor(ColorInfoBo pColorInfoBo)
        {
            var _ColorInfoManager = new ColorInfoManager();
            return _ColorInfoManager.AddColor(pColorInfoBo);
        }

        public CatalogDto UpdateColor(ColorInfoBo pColorInfoBo)
        {
            var _ColorInfoManager = new ColorInfoManager();
            return _ColorInfoManager.UpdateColor(pColorInfoBo);
        }

        public CatalogDto GetColorById(int pColorId)
        {
            var _ColorInfoManager = new ColorInfoManager();
            return _ColorInfoManager.GetColorById(pColorId);
        }

        public CatalogDto GetColorByCode(string pColorCode)
        {
            var _ColorInfoManager = new ColorInfoManager();
            return _ColorInfoManager.GetColorByCode(pColorCode);
        }

        public CatalogDto GetAllColors(bool? pIsActive)
        {
            var _ColorInfoManager = new ColorInfoManager();
            return _ColorInfoManager.GetAllColors(pIsActive);
        }
        #endregion Color

        #region  Customer
        public CatalogDto AddCustomer(CustomerInfoBo pCustomerInfoBo)
        {
            var _CustomerInfoManager = new CustomerInfoManager();
            return _CustomerInfoManager.AddCustomer(pCustomerInfoBo);
        }

        public CatalogDto UpdateCustomer(CustomerInfoBo pCustomerInfoBo)
        {
            var _CustomerInfoManager = new CustomerInfoManager();
            return _CustomerInfoManager.UpdateCustomer(pCustomerInfoBo);
        }

        public CatalogDto GetCustomerById(int pCustomerId)
        {
            var _CustomerInfoManager = new CustomerInfoManager();
            return _CustomerInfoManager.GetCustomerById(pCustomerId);
        }

        public CatalogDto GetCustomerByCode(string pCustomerCode)
        {
            var _CustomerInfoManager = new CustomerInfoManager();
            return _CustomerInfoManager.GetCustomerByCode(pCustomerCode);
        }

        public CatalogDto GetAllCustomers(bool? pIsActive)
        {
            var _CustomerInfoManager = new CustomerInfoManager();
            return _CustomerInfoManager.GetAllCustomers(pIsActive);
        }
        #endregion Customer

        #region  PaymentMode
        public CatalogDto AddPaymentMode(PaymentModeInfoBo pPaymentModeInfoBo)
        {
            var _PaymentModeInfoManager = new PaymentModeManager();
            return _PaymentModeInfoManager.AddPaymentMode(pPaymentModeInfoBo);
        }

        public CatalogDto UpdatePaymentMode(PaymentModeInfoBo pPaymentModeInfoBo)
        {
            var _PaymentModeInfoManager = new PaymentModeManager();
            return _PaymentModeInfoManager.UpdatePaymentMode(pPaymentModeInfoBo);
        }

        public CatalogDto GetPaymentModeById(int pPaymentModeId)
        {
            var _PaymentModeInfoManager = new PaymentModeManager();
            return _PaymentModeInfoManager.GetPaymentModeById(pPaymentModeId);
        }

        public CatalogDto GetPaymentModeByCode(string pPaymentModeCode)
        {
            var _PaymentModeInfoManager = new PaymentModeManager();
            return _PaymentModeInfoManager.GetPaymentModeByCode(pPaymentModeCode);
        }

        public CatalogDto GetAllPaymentModes(bool? pIsActive)
        {
            var _PaymentModeInfoManager = new PaymentModeManager();
            return _PaymentModeInfoManager.GetAllPaymentModes(pIsActive);
        }
        #endregion PaymentMode

        #region  Size
        public CatalogDto AddSize(SizeInfoBo pSizeInfoBo)
        {
            var _SizeInfoManager = new SizeInfoManager();
            return _SizeInfoManager.AddSize(pSizeInfoBo);
        }

        public CatalogDto UpdateSize(SizeInfoBo pSizeInfoBo)
        {
            var _SizeInfoManager = new SizeInfoManager();
            return _SizeInfoManager.UpdateSize(pSizeInfoBo);
        }

        public CatalogDto GetSizeById(int pSizeId)
        {
            var _SizeInfoManager = new SizeInfoManager();
            return _SizeInfoManager.GetSizeById(pSizeId);
        }

        public CatalogDto GetSizeByCode(string pSizeCode)
        {
            var _SizeInfoManager = new SizeInfoManager();
            return _SizeInfoManager.GetSizeByCode(pSizeCode);
        }

        public CatalogDto GetAllSizes(bool? pIsActive)
        {
            var _SizeInfoManager = new SizeInfoManager();
            return _SizeInfoManager.GetAllSizes(pIsActive);
        }
        #endregion Size

        #region  Style
        public CatalogDto AddStyle(StyleInfoBo pStyleInfoBo)
        {
            var _StyleInfoManager = new StyleInfoManager();
            return _StyleInfoManager.AddStyle(pStyleInfoBo);
        }

        public CatalogDto UpdateStyle(StyleInfoBo pStyleInfoBo)
        {
            var _StyleInfoManager = new StyleInfoManager();
            return _StyleInfoManager.UpdateStyle(pStyleInfoBo);
        }

        public CatalogDto GetStyleById(int pStyleId)
        {
            var _StyleInfoManager = new StyleInfoManager();
            return _StyleInfoManager.GetStyleById(pStyleId);
        }

        public CatalogDto GetStyleByCode(string pStyleCode)
        {
            var _StyleInfoManager = new StyleInfoManager();
            return _StyleInfoManager.GetStyleByCode(pStyleCode);
        }

        public CatalogDto GetAllStyles(bool? pIsActive)
        {
            var _StyleInfoManager = new StyleInfoManager();
            return _StyleInfoManager.GetAllStyles(pIsActive);
        }
        #endregion Style

        #region  Term
        public CatalogDto AddTerm(TermInfoBo pTermInfoBo)
        {
            var _TermInfoManager = new TermInfoManager();
            return _TermInfoManager.AddTerm(pTermInfoBo);
        }

        public CatalogDto UpdateTerm(TermInfoBo pTermInfoBo)
        {
            var _TermInfoManager = new TermInfoManager();
            return _TermInfoManager.UpdateTerm(pTermInfoBo);
        }

        public CatalogDto GetTermById(int pTermId)
        {
            var _TermInfoManager = new TermInfoManager();
            return _TermInfoManager.GetTermById(pTermId);
        }

        public CatalogDto GetTermByCode(string pTermCode)
        {
            var _TermInfoManager = new TermInfoManager();
            return _TermInfoManager.GetTermByCode(pTermCode);
        }

        public CatalogDto GetAllTerms(bool? pIsActive)
        {
            var _TermInfoManager = new TermInfoManager();
            return _TermInfoManager.GetAllTerms(pIsActive);
        }
        #endregion Term

        #region  POType
      
        public CatalogDto GetPOTypeById(int pPOTypeId)
        {
            var _POTypeManager = new POTypeManager();
            return _POTypeManager.GetPOTypeById(pPOTypeId);
        }

        public CatalogDto GetPOTypeByCode(string pPOTypeCode)
        {
            var _POTypeManager = new POTypeManager();
            return _POTypeManager.GetPOTypeByCode(pPOTypeCode);
        }

        public CatalogDto GetAllPOTypes(bool? pIsActive)
        {
            var _POTypeManager = new POTypeManager();
            return _POTypeManager.GetAllPOTypes(pIsActive);
        }
        #endregion POType

        #region  POLevel

        public CatalogDto GetPOLevelById(int pPOLevelId)
        {
            var _POLevelManager = new POLevelManager();
            return _POLevelManager.GetPOLevelById(pPOLevelId);
        }

        public CatalogDto GetPOLevelByCode(string pPOLevelCode)
        {
            var _POLevelManager = new POLevelManager();
            return _POLevelManager.GetPOLevelByCode(pPOLevelCode);
        }

        public CatalogDto GetAllPOLevels(bool? pIsActive)
        {
            var _POLevelManager = new POLevelManager();
            return _POLevelManager.GetAllPOLevels(pIsActive);
        }
        #endregion POLevel

        #region  POForm
       
        public CatalogDto GetPOFormById(int pPOFormId)
        {
            var _POFormManager = new POFormManager();
            return _POFormManager.GetPOFormById(pPOFormId);
        }

        public CatalogDto GetPOFormByCode(string pPOFormCode)
        {
            var _POFormManager = new POFormManager();
            return _POFormManager.GetPOFormByCode(pPOFormCode);
        }

        public CatalogDto GetAllPOForms(bool? pIsActive)
        {
            var _POFormManager = new POFormManager();
            return _POFormManager.GetAllPOForms(pIsActive);
        }
        #endregion POForm

        #region  PackingType

        public CatalogDto GetPackingTypeById(int pPackingTypeId)
        {
            var _PackingTypeManager = new PackingTypeManager();
            return _PackingTypeManager.GetPackingTypeById(pPackingTypeId);
        }

        public CatalogDto GetPackingTypeByCode(string pPackingTypeCode)
        {
            var _PackingTypeManager = new PackingTypeManager();
            return _PackingTypeManager.GetPackingTypeByCode(pPackingTypeCode);
        }

        public CatalogDto GetAllPackingTypes(bool? pIsActive)
        {
            var _PackingTypeManager = new PackingTypeManager();
            return _PackingTypeManager.GetAllPackingTypes(pIsActive);
        }
        #endregion PackingType

        #region  ShipmentTerm

        public CatalogDto GetShipmentTermById(int pShipmentTermId)
        {
            var _ShipmentTermManager = new ShipmentTermManager();
            return _ShipmentTermManager.GetShipmentTermById(pShipmentTermId);
        }

        public CatalogDto GetShipmentTermByCode(string pShipmentTermCode)
        {
            var _ShipmentTermManager = new ShipmentTermManager();
            return _ShipmentTermManager.GetShipmentTermByCode(pShipmentTermCode);
        }

        public CatalogDto GetAllShipmentTerms(bool? pIsActive)
        {
            var _ShipmentTermManager = new ShipmentTermManager();
            return _ShipmentTermManager.GetAllShipmentTerms(pIsActive);
        }
        #endregion ShipmentTerm

        #endregion Catalog

        #region Order

        #region  POM
        public OrderDto AddPOM(POMBo POMBo)
        {
            var _POManager = new POManager();
            return _POManager.AddPOM(POMBo);
        }

        public OrderDto UpdatePOM(POMBo POMBo)
        {
            var _POManager = new POManager();
            return _POManager.UpdatePOM(POMBo);
        }

        public OrderDto GetPOMById(int pPOMId)
        {
            var _POManager = new POManager();
            return _POManager.GetPOMById(pPOMId);
        }

        public OrderDto GetPOByPONo(string pPONo)
        {
            var _POManager = new POManager();
            return _POManager.GetPOByPONo(pPONo);
        }

        #endregion POM

        #region  POD
        public OrderDto AddPOD(PODBo PODBo)
        {
            var _POManager = new POManager();
            return _POManager.AddPOD(PODBo);
        }

        public OrderDto UpdatePOD(PODBo PODBo)
        {
            var _POManager = new POManager();
            return _POManager.UpdatePOD(PODBo);
        }

        public OrderDto GetPODById(int pPODId)
        {
            var _POManager = new POManager();
            return _POManager.GetPODById(pPODId);
        }

        #endregion POD

        #region  POSizeD
        public OrderDto AddPOSizeD(POSizeDBo POSizeDBo)
        {
            var _POManager = new POManager();
            return _POManager.AddPOSizeD(POSizeDBo);
        }

        public OrderDto UpdatePOSizeD(POSizeDBo POSizeDBo)
        {
            var _POManager = new POManager();
            return _POManager.UpdatePOSizeD(POSizeDBo);
        }

        public OrderDto GetPOSizeDById(int pPOSizeDId)
        {
            var _POManager = new POManager();
            return _POManager.GetPOSizeDById(pPOSizeDId);
        }

        #endregion POSizeD

        #endregion

        #region Packing

        #endregion
    }
}