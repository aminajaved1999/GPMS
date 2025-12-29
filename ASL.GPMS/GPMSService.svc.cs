using BLL.GPMS;
using Entities.GPMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace ASL.GPMS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GPMSService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GPMSService.svc or GPMSService.svc.cs at the Solution Explorer and start debugging.
    public class GPMSService : IGPMSService
    {
        /// <summary>
        /// get client requested ip
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetClientRequestIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;
            var logMgr = new LogManager();
            logMgr.ClientIPAddress = ip;
            return ip;
        }

        #region Fetch Skip N Get N
        public FetchDto SkipNGetN_OfCustomerDataWithSearch(int pCompanyID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            return new FetchManager().SkipNGetN_OfCustomerDataWithSearch(pCompanyID, pIsActive, pSearchTxt, pSkipNo, pTakeNo);
        }
        public FetchDto SkipNGetN_OfStyleDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            return new FetchManager().SkipNGetN_OfStyleDataWithSearch(pCustomerID, pIsActive, pSearchTxt, pSkipNo, pTakeNo);
        }
        public FetchDto SkipNGetN_OfSizeDataWithSearch(bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            return new FetchManager().SkipNGetN_OfSizeDataWithSearch(pIsActive, pSearchTxt, pSkipNo, pTakeNo);
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
            GetClientRequestIP();
            var _cartonInfoManager = new CartonInfoManager();
            return _cartonInfoManager.AddCarton(pCartonInfoBo);
        }

        public CatalogDto UpdateCarton(CartonInfoBo pCartonInfoBo)
        {
            GetClientRequestIP();
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
            GetClientRequestIP();
            var _ColorInfoManager = new ColorInfoManager();
            return _ColorInfoManager.AddColor(pColorInfoBo);
        }

        public CatalogDto UpdateColor(ColorInfoBo pColorInfoBo)
        {
            GetClientRequestIP();
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
            GetClientRequestIP();
            var _CustomerInfoManager = new CustomerInfoManager();
            return _CustomerInfoManager.AddCustomer(pCustomerInfoBo);
        }

        public CatalogDto UpdateCustomer(CustomerInfoBo pCustomerInfoBo)
        {
            GetClientRequestIP();
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
            GetClientRequestIP();
            var _PaymentModeInfoManager = new PaymentModeManager();
            return _PaymentModeInfoManager.AddPaymentMode(pPaymentModeInfoBo);
        }

        public CatalogDto UpdatePaymentMode(PaymentModeInfoBo pPaymentModeInfoBo)
        {
            GetClientRequestIP();
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
            GetClientRequestIP();
            var _SizeInfoManager = new SizeInfoManager();
            return _SizeInfoManager.AddSize(pSizeInfoBo);
        }

        public CatalogDto UpdateSize(SizeInfoBo pSizeInfoBo)
        {
            GetClientRequestIP();
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
            GetClientRequestIP();
            var _StyleInfoManager = new StyleInfoManager();
            return _StyleInfoManager.AddStyle(pStyleInfoBo);
        }

        public CatalogDto UpdateStyle(StyleInfoBo pStyleInfoBo)
        {
            GetClientRequestIP();
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
            GetClientRequestIP();
            var _TermInfoManager = new TermInfoManager();
            return _TermInfoManager.AddTerm(pTermInfoBo);
        }

        public CatalogDto UpdateTerm(TermInfoBo pTermInfoBo)
        {
            GetClientRequestIP();
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

        public CatalogDto GetPOFromById(int pPOFromId)
        {
            var _POFromManager = new POFormManager();
            return _POFromManager.GetPOFormById(pPOFromId);
        }

        public CatalogDto GetPOFromByCode(string pPOFromCode)
        {
            var _POFromManager = new POFormManager();
            return _POFromManager.GetPOFormByCode(pPOFromCode);
        }

        public CatalogDto GetAllPOFroms(bool? pIsActive)
        {
            var _POFromManager = new POFormManager();
            return _POFromManager.GetAllPOForms(pIsActive);
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

        #region  ShippingMethod
        public CatalogDto AddShippingMethod(ShippingMethodBo pShippingMethodBo)
        {
            GetClientRequestIP();
            var _ShippingMethodManager = new ShippingMethodManager();
            return _ShippingMethodManager.AddShippingMethod(pShippingMethodBo);
        }

        public CatalogDto UpdateShippingMethod(ShippingMethodBo pShippingMethodBo)
        {
            GetClientRequestIP();
            var _ShippingMethodManager = new ShippingMethodManager();
            return _ShippingMethodManager.UpdateShippingMethod(pShippingMethodBo);
        }

        public CatalogDto GetShippingMethodById(int pShippingMethodId)
        {
            var _ShippingMethodManager = new ShippingMethodManager();
            return _ShippingMethodManager.GetShippingMethodById(pShippingMethodId);
        }

        public CatalogDto GetShippingMethodByCode(string pShippingMethodCode)
        {
            var _ShippingMethodManager = new ShippingMethodManager();
            return _ShippingMethodManager.GetShippingMethodByCode(pShippingMethodCode);
        }

        public CatalogDto GetAllShippingMethods(bool? pIsActive)
        {
            var _ShippingMethodManager = new ShippingMethodManager();
            return _ShippingMethodManager.GetAllShippingMethods(pIsActive);
        }
        #endregion ShippingMethod

        #endregion Catalog

        #region Order

        #region  POM
        public OrderDto AddPOM(POMBo POMBo)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.AddPOM(POMBo);
        }

        public OrderDto UpdatePOM(POMBo POMBo)
        {
            GetClientRequestIP();
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

        public OrderDto DeletePOM(int Id, int userid)
        {
            var _POManager = new POManager();
            return _POManager.DeletePOM(Id, userid);
        }

        public OrderDto UpdatePOApprovedStatus(POApprovalStatusBo POApprovalStatuBo)
        {
            var _POManager = new POManager();
            return _POManager.UpdatePOApprovedStatus(POApprovalStatuBo);
        }

        public ValidationDto IsPONumberExist(string pPoNo)
        {
            var _POManager = new POManager();
            return _POManager.IsPONumberExist(pPoNo);
        }
        #endregion POM

        #region  POD
        public OrderDto AddPOD(List<PODBo> PODBoList)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.AddPOD(PODBoList);
        }

        public OrderDto UpdatePOD(PODBo PODBo)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.UpdatePOD(PODBo);
        }

        public OrderDto AddUpdatePOD(List<PODBo> PODBoList)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.AddUpdatePOD(PODBoList);
        }

        public OrderDto GetPODById(int pPODId)
        {
            var _POManager = new POManager();
            return _POManager.GetPODById(pPODId);
        }

        public OrderDto DeletePOD(int Id, int userid)
        {
            var _POManager = new POManager();
            return _POManager.DeletePOD(Id, userid);
        }

        #endregion POD

        #region  POSizeD
        public OrderDto AddPOSizeD(List<POSizeDBo> POSizeDBoList)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.AddPOSizeD(POSizeDBoList);
        }

        public OrderDto UpdatePOSizeD(POSizeDBo POSizeDBo)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.UpdatePOSizeD(POSizeDBo);
        }

        public OrderDto GetPOSizeDById(int pPOSizeDId)
        {
            var _POManager = new POManager();
            return _POManager.GetPOSizeDById(pPOSizeDId);
        }

        public OrderDto AddUpdatePOSizeD(List<POSizeDBo> POSizeDBoList)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.AddUpdatePOSizeD(POSizeDBoList);
        }

        public OrderDto DeletePOSizeD(int Id, int userId)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.DeletePOSizeD(Id, userId);
        }

        public OrderDto DeletePOSizeDCollection(List<int> pPOSizeDIDs, int userId)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.DeletePOSizeDCollection(pPOSizeDIDs, userId);
        }

        public ValidationDto IsItemExistInPO(string PONo, string ItemNo)
        {
            var _POManager = new POManager();
            return _POManager.IsItemExistInPO(PONo, ItemNo);
        }

        public ValidationDto IsPackQtyValid(int pCustomerID, string PONo, string ItemNo, int CurrentPackQty)
        {
            var _POManager = new POManager();
            return _POManager.IsPackQtyValid(pCustomerID, PONo, ItemNo, CurrentPackQty);
        }

        public OrderDto GetItemNo(int pCustomerID, int pStyleID, int pColorID, int pSizeID)
        {
            GetClientRequestIP();
            var _POManager = new POManager();
            return _POManager.GetItemNo(pCustomerID, pStyleID, pColorID, pSizeID);
        }

        #endregion POSizeD

        #endregion

        #region Packing

        #region PackingPlanData
        public PackingDto AddPackingPlanData(PackingDto packingDto)
        {
            GetClientRequestIP();
            var _PackingPlanDataManager = new PackingPlanDataManager();
            return _PackingPlanDataManager.AddPackingPlanData(packingDto);
        }

        public ValidationDto IsPackingPlanAlreadyProcessed(string pFileName)
        {
            var _PackingPlanDataManager = new PackingPlanDataManager();
            return _PackingPlanDataManager.IsPackingPlanAlreadyProcessed(pFileName);
        }

        #endregion  Packing Plan Data

        #region PackingInstructionM
        public PackingDto AddPackingInstructionM(PackingInstructionMBo packingInstructionMBo)
        {
            GetClientRequestIP();
            var _PackingInstructionMManager = new PackingInstructionMManager();
            return _PackingInstructionMManager.AddPackingInstructionM(packingInstructionMBo);
        }

        public PackingDto GetBoxDataByBarcode(string pBoxBacode)
        {
            var _PackingInstructionMManager = new PackingInstructionMManager();
            return _PackingInstructionMManager.GetBoxDataByBarcode(pBoxBacode);
        }

        public PackingDto SaveBoxPacking(int pPackingInstructionMID, int pUpdatedByID, string pUpdatedBy)
        {
            var _PackingInstructionMManager = new PackingInstructionMManager();
            return _PackingInstructionMManager.SaveBoxPacking(pPackingInstructionMID, pUpdatedByID, pUpdatedBy);
        }

        #endregion PackingInstructionM

        #region PackingInstructionD

        public PackingDto AddPackingInstructionD(PackingInstructionDBo packingInstructionDBo)
        {
            GetClientRequestIP();
            var _PackingInstructionDManager = new PackingInstructionDManager();
            return _PackingInstructionDManager.AddPackingInstructionD(packingInstructionDBo);
        }
        #endregion PackingInstructionD

        public PackingDto GetLabels_AcdSprt(int? pCustomerID, string pPONo, DateTime? pCreatedDate)
        {
            GetClientRequestIP();
            var _PackingPlanDataManager = new PackingPlanDataManager();
            return _PackingPlanDataManager.GetLabels_AcdSprt(pCustomerID, pPONo, pCreatedDate);
        }
        public PackingDto GetPackQty(int? pCustomerID, string pPONo, DateTime? pCreatedDate)
        {
            GetClientRequestIP();
            var _PackingPlanDataManager = new PackingPlanDataManager();
            return _PackingPlanDataManager.GetPackQty(pCustomerID, pPONo, pCreatedDate);
        }
        #endregion
    }
}