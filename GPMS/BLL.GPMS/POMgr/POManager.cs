using Entities.GPMS;
using MODEL.GPMS;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GPMS
{
    public class POManager : DbBase
    {
        #region POM
        /// <summary>
        /// Add new POM.
        /// </summary>
        /// <param name="pPOMBo"></param>
        /// <returns></returns>
        public OrderDto AddPOM(POMBo pPOMBo)
        {
            OrderDto response = new OrderDto();

            try
            {
                POM POM = new POM();

                // validate
                if (pPOMBo.CustomerID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pPOMBo.PONo == null)
                {
                    throw new UserException("Please provide a valid PO No.");
                }
                if (pPOMBo.POReceivedDate == null)
                {
                    throw new UserException("Please provide a valid POReceivedDate.");
                }
                if (pPOMBo.PaymentModeID <= 0)
                {
                    throw new UserException("Please provide a valid Payment Mode ID.");
                }
                if (pPOMBo.TermID <= 0)
                {
                    throw new UserException("Please provide a valid Term ID.");
                }
                if (pPOMBo.ShippingMethodID <= 0)
                {
                    throw new UserException("Please provide a valid Shipping Method ID.");
                }
                if (pPOMBo.POStatus == null)
                {
                    throw new UserException("Please provide a valid PO Status");
                }
                // validate

                POM.ID = pPOMBo.ID;
                POM.CustomerID = pPOMBo.CustomerID;
                POM.PONo = pPOMBo.PONo;
                POM.OriginalPONo = pPOMBo.OriginalPONo;
                POM.POReceivedDate = pPOMBo.POReceivedDate;
                POM.PaymentModeID = pPOMBo.PaymentModeID;
                POM.TermID = pPOMBo.TermID;
                POM.ShippingMethodID = pPOMBo.ShippingMethodID;
                POM.ShipmentTermID = pPOMBo.ShipmentTermID;
                POM.POFormID = pPOMBo.POFormID;
                POM.POTypeID = pPOMBo.POTypeID;
                POM.POLevelID = pPOMBo.POLevelID;
                POM.PackingTypeID = pPOMBo.PackingTypeID;
                POM.POStartDate = pPOMBo.POStartDate;
                POM.POStatus = pPOMBo.POStatus;
                POM.GarmentDescription = pPOMBo.GarmentDescription;
                POM.BillTo = pPOMBo.BillTo;
                POM.Season = pPOMBo.Season;
                POM.RivisionNo = pPOMBo.RivisionNo;
                POM.LastRevisionDate = pPOMBo.LastRevisionDate;
                POM.ClosingDate = pPOMBo.ClosingDate;
                POM.ClosedBy = pPOMBo.ClosedBy;
                POM.ShipDate = pPOMBo.ShipDate;
                POM.ShipRequestDate = pPOMBo.ShipRequestDate;
                POM.Description = pPOMBo.Description;
                POM.CreatedBy = pPOMBo.CreatedBy;
                POM.CreatedAt = DateTime.Now;
                POM.UpdatedBy = pPOMBo.UpdatedBy;
                POM.UpdatedAt = pPOMBo.UpdatedAt;
                POM.UpdatedCount = 0;
                POM.Notes = pPOMBo.Notes;

                // For CustomerInfo
                POM.CustomerInfo = new CustomerInfo();
                POM.CustomerInfo.ID = pPOMBo.CustomerInfoBo.ID;
                POM.CustomerInfo.CustomerCode = pPOMBo.CustomerInfoBo.CustomerCode;
                POM.CustomerInfo.CustomerName = pPOMBo.CustomerInfoBo.CustomerName;

                // For PackingType
                POM.PackingType = new PackingType();
                POM.PackingType.ID = pPOMBo.PackingTypeBo.ID;
                POM.PackingType.PackingTypeCode = pPOMBo.PackingTypeBo.PackingTypeCode;
                POM.PackingType.PackingTypeName = pPOMBo.PackingTypeBo.PackingTypeName;

                // For PaymentModeInfo
                POM.PaymentModeInfo = new PaymentModeInfo();
                POM.PaymentModeInfo.ID = pPOMBo.PaymentModeInfoBo.ID;
                POM.PaymentModeInfo.PaymentModeCode = pPOMBo.PaymentModeInfoBo.PaymentModeCode;
                POM.PaymentModeInfo.PaymentModeName = pPOMBo.PaymentModeInfoBo.PaymentModeName;

                // For POForm
                POM.POForm = new POForm();
                POM.POForm.ID = pPOMBo.POFormBo.ID;
                POM.POForm.POFormCode = pPOMBo.POFormBo.POFormCode;
                POM.POForm.POFormName = pPOMBo.POFormBo.POFormName;

                // For POLevel
                POM.POLevel = new POLevel();
                POM.POLevel.ID = pPOMBo.POLevelBo.ID;
                POM.POLevel.POLevelCode = pPOMBo.POLevelBo.POLevelCode;
                POM.POLevel.POLevelName = pPOMBo.POLevelBo.POLevelName;

                // For POType
                POM.POType = new POType();
                POM.POType.ID = pPOMBo.POTypeBo.ID;
                POM.POType.POTypeCode = pPOMBo.POTypeBo.POTypeCode;
                POM.POType.POTypeName = pPOMBo.POTypeBo.POTypeName;

                // For ShipmentTerm
                POM.ShipmentTerm = new ShipmentTerm();
                POM.ShipmentTerm.ID = pPOMBo.ShipmentTermBo.ID;
                POM.ShipmentTerm.ShipmentTermCode = pPOMBo.ShipmentTermBo.ShipmentTermCode;
                POM.ShipmentTerm.ShipmentTermName = pPOMBo.ShipmentTermBo.ShipmentTermName;

                // For ShippingMethod
                POM.ShippingMethod = new ShippingMethod();
                POM.ShippingMethod.ID = pPOMBo.ShippingMethodBo.ID;
                POM.ShippingMethod.ShippingMethodCode = pPOMBo.ShippingMethodBo.ShippingMethodCode;
                POM.ShippingMethod.ShippingMethodName = pPOMBo.ShippingMethodBo.ShippingMethodName;

                // For TermInfoBo
                POM.TermInfo = new TermInfo();
                POM.TermInfo.ID = pPOMBo.TermInfoBo.ID;
                POM.TermInfo.TermCode = pPOMBo.TermInfoBo.TermCode;
                POM.TermInfo.TermName = pPOMBo.TermInfoBo.TermName;

                EntitiesContext.POMs.Add(POM);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    response.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    response.DtoStatus = DtoStatus.RecordNotAdded;
                    response.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                }
            }
            catch (UserException ux)
            {
                response.DtoStatus = DtoStatus.RecordNotAdded;
                response.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                response.DtoStatus = DtoStatus.Error;
                response.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Update existing POM.
        /// </summary>
        /// <param name="pPOMBo"></param>
        /// <returns></returns>
        public OrderDto UpdatePOM(POMBo pPOMBo)
        {
            var res = new OrderDto();
            try
            {
                // validate
                if (pPOMBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                if (pPOMBo.CustomerID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pPOMBo.PONo == null)
                {
                    throw new UserException("Please provide a valid PO No.");
                }
                if (pPOMBo.POReceivedDate == null)
                {
                    throw new UserException("Please provide a valid POReceivedDate.");
                }
                if (pPOMBo.PaymentModeID <= 0)
                {
                    throw new UserException("Please provide a valid Payment Mode ID.");
                }
                if (pPOMBo.TermID <= 0)
                {
                    throw new UserException("Please provide a valid Term ID.");
                }
                if (pPOMBo.ShippingMethodID <= 0)
                {
                    throw new UserException("Please provide a valid Shipping Method ID.");
                }
                if (pPOMBo.POStatus == null)
                {
                    throw new UserException("Please provide a valid PO Status");
                }
                // validate

                var retPOM = EntitiesContext.POMs.Where(x => x.ID == pPOMBo.ID).FirstOrDefault();
                if (retPOM != null)
                {
                    retPOM.ID = pPOMBo.ID;
                    retPOM.CustomerID = pPOMBo.CustomerID;
                    retPOM.PONo = pPOMBo.PONo;
                    retPOM.OriginalPONo = pPOMBo.OriginalPONo;
                    retPOM.POReceivedDate = pPOMBo.POReceivedDate;
                    retPOM.PaymentModeID = pPOMBo.PaymentModeID;
                    retPOM.TermID = pPOMBo.TermID;
                    retPOM.ShippingMethodID = pPOMBo.ShippingMethodID;
                    retPOM.ShipmentTermID = pPOMBo.ShipmentTermID;
                    retPOM.POFormID = pPOMBo.POFormID;
                    retPOM.POTypeID = pPOMBo.POTypeID;
                    retPOM.POLevelID = pPOMBo.POLevelID;
                    retPOM.PackingTypeID = pPOMBo.PackingTypeID;
                    retPOM.POStartDate = pPOMBo.POStartDate;
                    retPOM.POStatus = pPOMBo.POStatus;
                    retPOM.GarmentDescription = pPOMBo.GarmentDescription;
                    retPOM.BillTo = pPOMBo.BillTo;
                    retPOM.Season = pPOMBo.Season;
                    retPOM.RivisionNo = pPOMBo.RivisionNo;
                    retPOM.LastRevisionDate = pPOMBo.LastRevisionDate;
                    retPOM.ClosingDate = pPOMBo.ClosingDate;
                    retPOM.ClosedBy = pPOMBo.ClosedBy;
                    retPOM.ShipDate = pPOMBo.ShipDate;
                    retPOM.ShipRequestDate = pPOMBo.ShipRequestDate;
                    retPOM.Description = pPOMBo.Description;
                    retPOM.CreatedBy = pPOMBo.CreatedBy;
                    retPOM.CreatedAt = pPOMBo.CreatedAt;
                    retPOM.UpdatedBy = pPOMBo.UpdatedBy;
                    retPOM.UpdatedAt = DateTime.Now;
                    retPOM.UpdatedCount = retPOM.UpdatedCount + 1;
                    retPOM.Notes = pPOMBo.Notes;

                    // For CustomerInfo
                    retPOM.CustomerInfo = new CustomerInfo();
                    retPOM.CustomerInfo.ID = pPOMBo.CustomerInfoBo.ID;
                    retPOM.CustomerInfo.CustomerCode = pPOMBo.CustomerInfoBo.CustomerCode;
                    retPOM.CustomerInfo.CustomerName = pPOMBo.CustomerInfoBo.CustomerName;

                    // For PackingType
                    retPOM.PackingType = new PackingType();
                    retPOM.PackingType.ID = pPOMBo.PackingTypeBo.ID;
                    retPOM.PackingType.PackingTypeCode = pPOMBo.PackingTypeBo.PackingTypeCode;
                    retPOM.PackingType.PackingTypeName = pPOMBo.PackingTypeBo.PackingTypeName;

                    // For PaymentModeInfo
                    retPOM.PaymentModeInfo = new PaymentModeInfo();
                    retPOM.PaymentModeInfo.ID = pPOMBo.PaymentModeInfoBo.ID;
                    retPOM.PaymentModeInfo.PaymentModeCode = pPOMBo.PaymentModeInfoBo.PaymentModeCode;
                    retPOM.PaymentModeInfo.PaymentModeName = pPOMBo.PaymentModeInfoBo.PaymentModeName;

                    // For POForm
                    retPOM.POForm = new POForm();
                    retPOM.POForm.ID = pPOMBo.POFormBo.ID;
                    retPOM.POForm.POFormCode = pPOMBo.POFormBo.POFormCode;
                    retPOM.POForm.POFormName = pPOMBo.POFormBo.POFormName;

                    // For POLevel
                    retPOM.POLevel = new POLevel();
                    retPOM.POLevel.ID = pPOMBo.POLevelBo.ID;
                    retPOM.POLevel.POLevelCode = pPOMBo.POLevelBo.POLevelCode;
                    retPOM.POLevel.POLevelName = pPOMBo.POLevelBo.POLevelName;

                    // For POType
                    retPOM.POType = new POType();
                    retPOM.POType.ID = pPOMBo.POTypeBo.ID;
                    retPOM.POType.POTypeCode = pPOMBo.POTypeBo.POTypeCode;
                    retPOM.POType.POTypeName = pPOMBo.POTypeBo.POTypeName;

                    // For ShipmentTerm
                    retPOM.ShipmentTerm = new ShipmentTerm();
                    retPOM.ShipmentTerm.ID = pPOMBo.ShipmentTermBo.ID;
                    retPOM.ShipmentTerm.ShipmentTermCode = pPOMBo.ShipmentTermBo.ShipmentTermCode;
                    retPOM.ShipmentTerm.ShipmentTermName = pPOMBo.ShipmentTermBo.ShipmentTermName;

                    // For ShippingMethod
                    retPOM.ShippingMethod = new ShippingMethod();
                    retPOM.ShippingMethod.ID = pPOMBo.ShippingMethodBo.ID;
                    retPOM.ShippingMethod.ShippingMethodCode = pPOMBo.ShippingMethodBo.ShippingMethodCode;
                    retPOM.ShippingMethod.ShippingMethodName = pPOMBo.ShippingMethodBo.ShippingMethodName;

                    // For TermInfo
                    retPOM.TermInfo = new TermInfo();
                    retPOM.TermInfo.ID = pPOMBo.TermInfoBo.ID;
                    retPOM.TermInfo.TermCode = pPOMBo.TermInfoBo.TermCode;
                    retPOM.TermInfo.TermName = pPOMBo.TermInfoBo.TermName;

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        res.DtoStatus = DtoStatus.Success;

                    }
                    else if (response <= 0)
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdatedWithoutChanges;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdated;
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }

            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = sqlEx.Message.ToString();

                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.Error;
                    res.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.RecordNotUpdated;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// Get POM info. against given POM ID.
        /// </summary>
        /// <param name="pPOMId"></param>
        /// <returns></returns>
        public OrderDto GetPOMById(int pPOMId)
        {
            var res = new OrderDto();
            try
            {
                // validate
                if (pPOMId > 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var pom = EntitiesContext.POMs.Where(x => x.ID == pPOMId).FirstOrDefault();
                if (pom != null)
                {
                    res.POMBo = new POMBo();
                    res.POMBo.ID = pom.ID;
                    res.POMBo.CustomerID = pom.CustomerID;
                    res.POMBo.PONo = pom.PONo;
                    res.POMBo.OriginalPONo = pom.OriginalPONo;
                    res.POMBo.POReceivedDate = pom.POReceivedDate;
                    res.POMBo.PaymentModeID = pom.PaymentModeID;
                    res.POMBo.TermID = pom.TermID;
                    res.POMBo.ShippingMethodID = pom.ShippingMethodID;
                    res.POMBo.ShipmentTermID = pom.ShipmentTermID;
                    res.POMBo.POFormID = pom.POFormID;
                    res.POMBo.POTypeID = pom.POTypeID;
                    res.POMBo.POLevelID = pom.POLevelID;
                    res.POMBo.PackingTypeID = pom.PackingTypeID;
                    res.POMBo.POStartDate = pom.POStartDate;
                    res.POMBo.POStatus = pom.POStatus;
                    res.POMBo.GarmentDescription = pom.GarmentDescription;
                    res.POMBo.BillTo = pom.BillTo;
                    res.POMBo.Season = pom.Season;
                    res.POMBo.RivisionNo = pom.RivisionNo;
                    res.POMBo.LastRevisionDate = pom.LastRevisionDate;
                    res.POMBo.ClosingDate = pom.ClosingDate;
                    res.POMBo.ClosedBy = pom.ClosedBy;
                    res.POMBo.ShipDate = pom.ShipDate;
                    res.POMBo.ShipRequestDate = pom.ShipRequestDate;
                    res.POMBo.Description = pom.Description;
                    res.POMBo.CreatedBy = pom.CreatedBy;
                    res.POMBo.CreatedAt = pom.CreatedAt;
                    res.POMBo.UpdatedBy = pom.UpdatedBy;
                    res.POMBo.UpdatedAt = pom.UpdatedAt;
                    res.POMBo.UpdatedCount = pom.UpdatedCount;
                    res.POMBo.Notes = pom.Notes;

                    // For CustomerInfo
                    res.POMBo.CustomerInfoBo = new CustomerInfoBo();
                    res.POMBo.CustomerInfoBo.ID = pom.CustomerInfo.ID;
                    res.POMBo.CustomerInfoBo.CustomerCode = pom.CustomerInfo.CustomerCode;
                    res.POMBo.CustomerInfoBo.CustomerName = pom.CustomerInfo.CustomerName;

                    // For PackingType
                    res.POMBo.PackingTypeBo = new PackingTypeBo();
                    res.POMBo.PackingTypeBo.ID = pom.PackingType.ID;
                    res.POMBo.PackingTypeBo.PackingTypeCode = pom.PackingType.PackingTypeCode;
                    res.POMBo.PackingTypeBo.PackingTypeName = pom.PackingType.PackingTypeName;

                    // For PaymentModeInfo
                    res.POMBo.PaymentModeInfoBo = new PaymentModeInfoBo();
                    res.POMBo.PaymentModeInfoBo.ID = pom.PaymentModeInfo.ID;
                    res.POMBo.PaymentModeInfoBo.PaymentModeCode = pom.PaymentModeInfo.PaymentModeCode;
                    res.POMBo.PaymentModeInfoBo.PaymentModeName = pom.PaymentModeInfo.PaymentModeName;

                    // For POForm
                    res.POMBo.POFormBo = new POFormBo();
                    res.POMBo.POFormBo.ID = pom.POForm.ID;
                    res.POMBo.POFormBo.POFormCode = pom.POForm.POFormCode;
                    res.POMBo.POFormBo.POFormName = pom.POForm.POFormName;

                    // For POLevel
                    res.POMBo.POLevelBo = new POLevelBo();
                    res.POMBo.POLevelBo.ID = pom.POLevel.ID;
                    res.POMBo.POLevelBo.POLevelCode = pom.POLevel.POLevelCode;
                    res.POMBo.POLevelBo.POLevelName = pom.POLevel.POLevelName;

                    // For POType
                    res.POMBo.POTypeBo = new POTypeBo();
                    res.POMBo.POTypeBo.ID = pom.POType.ID;
                    res.POMBo.POTypeBo.POTypeCode = pom.POType.POTypeCode;
                    res.POMBo.POTypeBo.POTypeName = pom.POType.POTypeName;

                    // For ShipmentTerm
                    res.POMBo.ShipmentTermBo = new ShipmentTermBo();
                    res.POMBo.ShipmentTermBo.ID = pom.ShipmentTerm.ID;
                    res.POMBo.ShipmentTermBo.ShipmentTermCode = pom.ShipmentTerm.ShipmentTermCode;
                    res.POMBo.ShipmentTermBo.ShipmentTermName = pom.ShipmentTerm.ShipmentTermName;

                    // For ShippingMethod
                    res.POMBo.ShippingMethodBo = new ShippingMethodBo();
                    res.POMBo.ShippingMethodBo.ID = pom.ShippingMethod.ID;
                    res.POMBo.ShippingMethodBo.ShippingMethodCode = pom.ShippingMethod.ShippingMethodCode;
                    res.POMBo.ShippingMethodBo.ShippingMethodName = pom.ShippingMethod.ShippingMethodName;

                    // For TermInfoBo
                    res.POMBo.TermInfoBo = new TermInfoBo();
                    res.POMBo.TermInfoBo.ID = pom.TermInfo.ID;
                    res.POMBo.TermInfoBo.TermCode = pom.TermInfo.TermCode;
                    res.POMBo.TermInfoBo.TermName = pom.TermInfo.TermName;

                    res.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// Get PO info. against given PO no.
        /// </summary>
        /// <param name="pPOMId"></param>
        /// <returns></returns>
        public OrderDto GetPOByPONo(string pPONo)
        {
            var response = new OrderDto();
            try
            {
                // validate
                if (pPONo == null)
                {
                    throw new UserException("Please provide a valid pPONo.");
                }
                // validate

                response.DtoStatus = DtoStatus.Failed;
                var pom = EntitiesContext.POMs.Where(x => x.PONo == pPONo).FirstOrDefault();
                if (pom != null)
                {
                    response.POMBo = new POMBo();
                    response.POMBo.ID = pom.ID;
                    response.POMBo.CustomerID = pom.CustomerID;
                    response.POMBo.PONo = pom.PONo;
                    response.POMBo.OriginalPONo = pom.OriginalPONo;
                    response.POMBo.POReceivedDate = pom.POReceivedDate;
                    response.POMBo.PaymentModeID = pom.PaymentModeID;
                    response.POMBo.TermID = pom.TermID;
                    response.POMBo.ShippingMethodID = pom.ShippingMethodID;
                    response.POMBo.ShipmentTermID = pom.ShipmentTermID;
                    response.POMBo.POFormID = pom.POFormID;
                    response.POMBo.POTypeID = pom.POTypeID;
                    response.POMBo.POLevelID = pom.POLevelID;
                    response.POMBo.PackingTypeID = pom.PackingTypeID;
                    response.POMBo.POStartDate = pom.POStartDate;
                    response.POMBo.POStatus = pom.POStatus;
                    response.POMBo.GarmentDescription = pom.GarmentDescription;
                    response.POMBo.BillTo = pom.BillTo;
                    response.POMBo.Season = pom.Season;
                    response.POMBo.RivisionNo = pom.RivisionNo;
                    response.POMBo.LastRevisionDate = pom.LastRevisionDate;
                    response.POMBo.ClosingDate = pom.ClosingDate;
                    response.POMBo.ClosedBy = pom.ClosedBy;
                    response.POMBo.ShipDate = pom.ShipDate;
                    response.POMBo.ShipRequestDate = pom.ShipRequestDate;
                    response.POMBo.Description = pom.Description;
                    response.POMBo.CreatedBy = pom.CreatedBy;
                    response.POMBo.CreatedAt = pom.CreatedAt;
                    response.POMBo.UpdatedBy = pom.UpdatedBy;
                    response.POMBo.UpdatedAt = pom.UpdatedAt;
                    response.POMBo.UpdatedCount = pom.UpdatedCount;
                    response.POMBo.Notes = pom.Notes;

                    response.POMBo.PODCollection = new List<PODBo>();
                    foreach (var pod in pom.PODs)
                    {
                        PODBo pODBo = new PODBo();
                        pODBo.ID = pod.ID;
                        pODBo.POMID = pod.POMID;
                        pODBo.StyleID = pod.StyleID;
                        pODBo.ColorID = pod.ColorID;
                        pODBo.ComboCode = pod.ComboCode;
                        pODBo.IsPilotRun = pod.IsPilotRun;
                        pODBo.Description = pod.Description;
                        pODBo.CreatedBy = pod.CreatedBy;
                        pODBo.CreatedAt = pod.CreatedAt;
                        pODBo.UpdatedBy = pod.UpdatedBy;
                        pODBo.UpdatedAt = pod.UpdatedAt;
                        pODBo.UpdatedCount = pod.UpdatedCount;
                        pODBo.Notes = pod.Notes;

                        //For POM
                        pODBo.POMBo = new POMBo();
                        pODBo.POMBo.ID = pod.POM.ID;

                        //For ColorInfo
                        pODBo.ColorInfoBo = new ColorInfoBo();
                        pODBo.ColorInfoBo.ID = pod.ColorInfo.ID;
                        pODBo.ColorInfoBo.ColorCode = pod.ColorInfo.ColorCode;
                        pODBo.ColorInfoBo.ColorName = pod.ColorInfo.ColorName;

                        //For StyleInfo
                        pODBo.StyleInfoBo = new StyleInfoBo();
                        pODBo.StyleInfoBo.ID = pod.StyleInfo.ID;
                        pODBo.StyleInfoBo.StyleCode = pod.StyleInfo.StyleCode;
                        pODBo.StyleInfoBo.StyleName = pod.StyleInfo.StyleName;

                        response.POMBo.PODCollection.Add(pODBo);
                    }

                    // For CustomerInfo
                    response.POMBo.CustomerInfoBo = new CustomerInfoBo();
                    response.POMBo.CustomerInfoBo.ID = pom.CustomerInfo.ID;
                    response.POMBo.CustomerInfoBo.CustomerCode = pom.CustomerInfo.CustomerCode;
                    response.POMBo.CustomerInfoBo.CustomerName = pom.CustomerInfo.CustomerName;

                    // For PackingType
                    response.POMBo.PackingTypeBo = new PackingTypeBo();
                    response.POMBo.PackingTypeBo.ID = pom.PackingType.ID;
                    response.POMBo.PackingTypeBo.PackingTypeCode = pom.PackingType.PackingTypeCode;
                    response.POMBo.PackingTypeBo.PackingTypeName = pom.PackingType.PackingTypeName;

                    // For PaymentModeInfo
                    response.POMBo.PaymentModeInfoBo = new PaymentModeInfoBo();
                    response.POMBo.PaymentModeInfoBo.ID = pom.PaymentModeInfo.ID;
                    response.POMBo.PaymentModeInfoBo.PaymentModeCode = pom.PaymentModeInfo.PaymentModeCode;
                    response.POMBo.PaymentModeInfoBo.PaymentModeName = pom.PaymentModeInfo.PaymentModeName;

                    // For POForm
                    response.POMBo.POFormBo = new POFormBo();
                    response.POMBo.POFormBo.ID = pom.POForm.ID;
                    response.POMBo.POFormBo.POFormCode = pom.POForm.POFormCode;
                    response.POMBo.POFormBo.POFormName = pom.POForm.POFormName;

                    // For POLevel
                    response.POMBo.POLevelBo = new POLevelBo();
                    response.POMBo.POLevelBo.ID = pom.POLevel.ID;
                    response.POMBo.POLevelBo.POLevelCode = pom.POLevel.POLevelCode;
                    response.POMBo.POLevelBo.POLevelName = pom.POLevel.POLevelName;

                    // For POType
                    response.POMBo.POTypeBo = new POTypeBo();
                    response.POMBo.POTypeBo.ID = pom.POType.ID;
                    response.POMBo.POTypeBo.POTypeCode = pom.POType.POTypeCode;
                    response.POMBo.POTypeBo.POTypeName = pom.POType.POTypeName;

                    // For ShipmentTerm
                    response.POMBo.ShipmentTermBo = new ShipmentTermBo();
                    response.POMBo.ShipmentTermBo.ID = pom.ShipmentTerm.ID;
                    response.POMBo.ShipmentTermBo.ShipmentTermCode = pom.ShipmentTerm.ShipmentTermCode;
                    response.POMBo.ShipmentTermBo.ShipmentTermName = pom.ShipmentTerm.ShipmentTermName;

                    // For ShippingMethod
                    response.POMBo.ShippingMethodBo = new ShippingMethodBo();
                    response.POMBo.ShippingMethodBo.ID = pom.ShippingMethod.ID;
                    response.POMBo.ShippingMethodBo.ShippingMethodCode = pom.ShippingMethod.ShippingMethodCode;
                    response.POMBo.ShippingMethodBo.ShippingMethodName = pom.ShippingMethod.ShippingMethodName;

                    // For TermInfoBo
                    response.POMBo.TermInfoBo = new TermInfoBo();
                    response.POMBo.TermInfoBo.ID = pom.TermInfo.ID;
                    response.POMBo.TermInfoBo.TermCode = pom.TermInfo.TermCode;
                    response.POMBo.TermInfoBo.TermName = pom.TermInfo.TermName;


                    response.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    response.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                response.DtoStatus = DtoStatus.Error;
                response.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                response.DtoStatus = DtoStatus.Error;
                response.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return response;
        }

        #endregion POM

        #region POD
        /// <summary>
        /// Add new POD.
        /// </summary>
        /// <param name="pPODBo"></param>
        /// <returns></returns>
        public OrderDto AddPOD(PODBo pPODBo)
        {
            OrderDto response = new OrderDto();

            try
            {
                POD POD = new POD();

                // validate
                if (pPODBo.POMID <= 0)
                {
                    throw new UserException("Please provide a valid POM ID.");
                }
                if (pPODBo.StyleID <= 0)
                {
                    throw new UserException("Please provide a valid Style ID");
                }
                if (pPODBo.ColorID <= 0)
                {
                    throw new UserException("Please provide a valid Color ID.");
                }
                // validate

                POD.ID = pPODBo.ID;
                POD.POMID = pPODBo.POMID;
                POD.StyleID = pPODBo.StyleID;
                POD.ColorID = pPODBo.ColorID;
                POD.ComboCode = pPODBo.ComboCode;
                POD.IsPilotRun = pPODBo.IsPilotRun;
                POD.Description = pPODBo.Description;
                POD.CreatedBy = pPODBo.CreatedBy;
                POD.CreatedAt = DateTime.Now;
                POD.UpdatedBy = pPODBo.UpdatedBy;
                POD.UpdatedAt = pPODBo.UpdatedAt;
                POD.UpdatedCount = 0;
                POD.Notes = pPODBo.Notes;

                //For POM
                POD.POM = new POM();
                POD.POM.ID = pPODBo.POMBo.ID;

                //For ColorInfo
                POD.ColorInfo = new ColorInfo();
                POD.ColorInfo.ID = pPODBo.ColorInfoBo.ID;
                POD.ColorInfo.ColorCode = pPODBo.ColorInfoBo.ColorCode;
                POD.ColorInfo.ColorName = pPODBo.ColorInfoBo.ColorName;

                //For StyleInfo
                POD.StyleInfo = new StyleInfo();
                POD.StyleInfo.ID = pPODBo.StyleInfoBo.ID;
                POD.StyleInfo.StyleCode = pPODBo.StyleInfoBo.StyleCode;
                POD.StyleInfo.StyleName = pPODBo.StyleInfoBo.StyleName;

                EntitiesContext.PODs.Add(POD);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    response.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    response.DtoStatus = DtoStatus.RecordNotAdded;
                    response.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                }
            }
            catch (UserException ux)
            {
                response.DtoStatus = DtoStatus.RecordNotAdded;
                response.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                response.DtoStatus = DtoStatus.Error;
                response.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Update existing POD.
        /// </summary>
        /// <param name="pPODBo"></param>
        /// <returns></returns>
        public OrderDto UpdatePOD(PODBo pPODBo)
        {
            var res = new OrderDto();
            try
            {
                // validate
                if (pPODBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                if (pPODBo.POMID <= 0)
                {
                    throw new UserException("Please provide a valid POM ID.");
                }
                if (pPODBo.StyleID <= 0)
                {
                    throw new UserException("Please provide a valid Style ID");
                }
                if (pPODBo.ColorID <= 0)
                {
                    throw new UserException("Please provide a valid Color ID.");
                }
                // validate

                var retPOD = EntitiesContext.PODs.Where(x => x.ID == pPODBo.ID).FirstOrDefault();
                if (retPOD != null)
                {
                    retPOD.ID = pPODBo.ID;
                    retPOD.POMID = pPODBo.POMID;
                    retPOD.StyleID = pPODBo.StyleID;
                    retPOD.ColorID = pPODBo.ColorID;
                    retPOD.ComboCode = pPODBo.ComboCode;
                    retPOD.IsPilotRun = pPODBo.IsPilotRun;
                    retPOD.Description = pPODBo.Description;
                    retPOD.CreatedBy = pPODBo.CreatedBy;
                    retPOD.CreatedAt = pPODBo.CreatedAt;
                    retPOD.UpdatedBy = pPODBo.UpdatedBy;
                    retPOD.UpdatedAt = DateTime.Now;
                    retPOD.UpdatedCount = retPOD.UpdatedCount + 1;
                    retPOD.Notes = pPODBo.Notes;

                    //For POM
                    retPOD.POM = new POM();
                    retPOD.POM.ID = pPODBo.POMBo.ID;

                    //For ColorInfo
                    retPOD.ColorInfo = new ColorInfo();
                    retPOD.ColorInfo.ID = pPODBo.ColorInfoBo.ID;
                    retPOD.ColorInfo.ColorCode = pPODBo.ColorInfoBo.ColorCode;
                    retPOD.ColorInfo.ColorName = pPODBo.ColorInfoBo.ColorName;

                    //For StyleInfo
                    retPOD.StyleInfo = new StyleInfo();
                    retPOD.StyleInfo.ID = pPODBo.StyleInfoBo.ID;
                    retPOD.StyleInfo.StyleCode = pPODBo.StyleInfoBo.StyleCode;
                    retPOD.StyleInfo.StyleName = pPODBo.StyleInfoBo.StyleName;

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        res.DtoStatus = DtoStatus.Success;

                    }
                    else if (response <= 0)
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdatedWithoutChanges;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdated;
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }

            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = sqlEx.Message.ToString();

                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.Error;
                    res.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.RecordNotAdded;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// Get POD info. against given POD ID.
        /// </summary>
        /// <param name="pPODId"></param>
        /// <returns></returns>
        public OrderDto GetPODById(int pPODId)
        {
            var res = new OrderDto();
            try
            {
                // validate
                if (pPODId > 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var poD = EntitiesContext.PODs.Where(x => x.ID == pPODId).FirstOrDefault();
                if (poD != null)
                {
                    res.PODBo.ID = poD.ID;
                    res.PODBo.POMID = poD.POMID;
                    res.PODBo.StyleID = poD.StyleID;
                    res.PODBo.ColorID = poD.ColorID;
                    res.PODBo.ComboCode = poD.ComboCode;
                    res.PODBo.IsPilotRun = poD.IsPilotRun;
                    res.PODBo.Description = poD.Description;
                    res.PODBo.CreatedBy = poD.CreatedBy;
                    res.PODBo.CreatedAt = poD.CreatedAt;
                    res.PODBo.UpdatedBy = poD.UpdatedBy;
                    res.PODBo.UpdatedAt = DateTime.Now;
                    res.PODBo.UpdatedCount = poD.UpdatedCount;
                    res.PODBo.Notes = poD.Notes;

                    //For POM
                    res.PODBo.POMBo = new POMBo();
                    res.PODBo.POMBo.ID = poD.POM.ID;

                    //For ColorInfo
                    res.PODBo.ColorInfoBo = new ColorInfoBo();
                    res.PODBo.ColorInfoBo.ID = poD.ColorInfo.ID;
                    res.PODBo.ColorInfoBo.ColorCode = poD.ColorInfo.ColorCode;
                    res.PODBo.ColorInfoBo.ColorName = poD.ColorInfo.ColorName;

                    //For StyleInfo
                    res.PODBo.StyleInfoBo = new StyleInfoBo();
                    res.PODBo.StyleInfoBo.ID = poD.StyleInfo.ID;
                    res.PODBo.StyleInfoBo.StyleCode = poD.StyleInfo.StyleCode;
                    res.PODBo.StyleInfoBo.StyleName = poD.StyleInfo.StyleName;

                    res.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }
        #endregion POD

        #region POSizeD
        /// <summary>
        /// Add new POSizeD.
        /// </summary>
        /// <param name="pPOSizeDBo"></param>
        /// <returns></returns>
        public OrderDto AddPOSizeD(POSizeDBo pPOSizeDBo)
        {
            OrderDto response = new OrderDto();

            try
            {
                POSizeD POSizeD = new POSizeD();

                // validate
                if (pPOSizeDBo.PODID <= 0)
                {
                    throw new UserException("Please provide a valid POD ID.");
                }
                if (pPOSizeDBo.ColorID <= 0)
                {
                    throw new UserException("Please provide a valid Color ID.");
                }
                if (pPOSizeDBo.SizeID <= 0)
                {
                    throw new UserException("Please provide a valid Size ID.");
                }
                if (pPOSizeDBo.Price <= 0)
                {
                    throw new UserException("Please provide a valid Price.");
                }
                // validate

                POSizeD.ID = pPOSizeDBo.ID;
                POSizeD.PODID = pPOSizeDBo.PODID;
                POSizeD.ColorID = pPOSizeDBo.ColorID;
                POSizeD.SizeID = pPOSizeDBo.SizeID;
                POSizeD.Qty = pPOSizeDBo.Qty;
                POSizeD.Price = pPOSizeDBo.Price;
                POSizeD.Description = pPOSizeDBo.Description;
                POSizeD.CreatedBy = pPOSizeDBo.CreatedBy;
                POSizeD.CreatedAt = DateTime.Now;
                POSizeD.UpdatedBy = pPOSizeDBo.UpdatedBy;
                POSizeD.UpdatedAt = pPOSizeDBo.UpdatedAt;
                POSizeD.UpdatedCount = pPOSizeDBo.UpdatedCount;
                POSizeD.Notes = pPOSizeDBo.Notes;

                //For POM
                POSizeD.POD = new POD();
                POSizeD.POD.ID = pPOSizeDBo.PODBo.ID;

                //For ColorInfo
                POSizeD.ColorInfo = new ColorInfo();
                POSizeD.ColorInfo.ID = pPOSizeDBo.ColorInfoBo.ID;
                POSizeD.ColorInfo.ColorCode = pPOSizeDBo.ColorInfoBo.ColorCode;
                POSizeD.ColorInfo.ColorName = pPOSizeDBo.ColorInfoBo.ColorName;


                EntitiesContext.POSizeDs.Add(POSizeD);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    response.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    response.DtoStatus = DtoStatus.RecordNotAdded;
                    response.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                }
            }
            catch (UserException ux)
            {
                response.DtoStatus = DtoStatus.RecordNotAdded;
                response.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                response.DtoStatus = DtoStatus.Error;
                response.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Update existing POSizeD.
        /// </summary>
        /// <param name="pPOSizeDBo"></param>
        /// <returns></returns>
        public OrderDto UpdatePOSizeD(POSizeDBo pPOSizeDBo)
        {
            var res = new OrderDto();
            try
            {
                // validate
                if (pPOSizeDBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                if (pPOSizeDBo.PODID <= 0)
                {
                    throw new UserException("Please provide a valid POD ID.");
                }
                if (pPOSizeDBo.ColorID <= 0)
                {
                    throw new UserException("Please provide a valid Color ID.");
                }
                if (pPOSizeDBo.SizeID <= 0)
                {
                    throw new UserException("Please provide a valid Size ID.");
                }
                if (pPOSizeDBo.Price <= 0)
                {
                    throw new UserException("Please provide a valid Price.");
                }
                // validate

                var retPOSizeD = EntitiesContext.POSizeDs.Where(x => x.ID == pPOSizeDBo.ID).FirstOrDefault();
                if (retPOSizeD != null)
                {
                    retPOSizeD.ID = pPOSizeDBo.ID;
                    retPOSizeD.PODID = pPOSizeDBo.PODID;
                    retPOSizeD.ColorID = pPOSizeDBo.ColorID;
                    retPOSizeD.SizeID = pPOSizeDBo.SizeID;
                    retPOSizeD.Qty = pPOSizeDBo.Qty;
                    retPOSizeD.Price = pPOSizeDBo.Price;
                    retPOSizeD.Description = pPOSizeDBo.Description;
                    retPOSizeD.CreatedBy = pPOSizeDBo.CreatedBy;
                    retPOSizeD.CreatedAt = pPOSizeDBo.CreatedAt;
                    retPOSizeD.UpdatedBy = pPOSizeDBo.UpdatedBy;
                    retPOSizeD.UpdatedAt = DateTime.Now;
                    retPOSizeD.UpdatedCount = retPOSizeD.UpdatedCount + 1;
                    retPOSizeD.Notes = pPOSizeDBo.Notes;

                    //For POD
                    retPOSizeD.POD = new POD();
                    retPOSizeD.POD.ID = pPOSizeDBo.PODBo.ID;

                    //For ColorInfo
                    retPOSizeD.ColorInfo = new ColorInfo();
                    retPOSizeD.ColorInfo.ID = pPOSizeDBo.ColorInfoBo.ID;
                    retPOSizeD.ColorInfo.ColorCode = pPOSizeDBo.ColorInfoBo.ColorCode;
                    retPOSizeD.ColorInfo.ColorName = pPOSizeDBo.ColorInfoBo.ColorName;


                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        res.DtoStatus = DtoStatus.Success;

                    }
                    else if (response <= 0)
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdatedWithoutChanges;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdated;
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }

            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = sqlEx.Message.ToString();

                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.Error;
                    res.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.RecordNotAdded;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// Get POSizeD info. against given POSizeD ID.
        /// </summary>
        /// <param name="pPOSizeDId"></param>
        /// <returns></returns>
        public OrderDto GetPOSizeDById(int pPOSizeDId)
        {
            var response = new OrderDto();
            try
            {
                // validate
                if (pPOSizeDId > 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                // validate

                response.DtoStatus = DtoStatus.Failed;
                var POSizeD = EntitiesContext.POSizeDs.Where(x => x.ID == pPOSizeDId).FirstOrDefault();
                if (POSizeD != null)
                {
                    response.POSizeDBo.ID = POSizeD.ID;
                    response.POSizeDBo.PODID = POSizeD.PODID;
                    response.POSizeDBo.ColorID = POSizeD.ColorID;
                    response.POSizeDBo.SizeID = POSizeD.SizeID;
                    response.POSizeDBo.Qty = POSizeD.Qty;
                    response.POSizeDBo.Price = POSizeD.Price;
                    response.POSizeDBo.Description = POSizeD.Description;
                    response.POSizeDBo.CreatedBy = POSizeD.CreatedBy;
                    response.POSizeDBo.CreatedAt = POSizeD.CreatedAt;
                    response.POSizeDBo.UpdatedBy = POSizeD.UpdatedBy;
                    response.POSizeDBo.UpdatedAt = POSizeD.UpdatedAt;
                    response.POSizeDBo.UpdatedCount = POSizeD.UpdatedCount;
                    response.POSizeDBo.Notes = POSizeD.Notes;
                    
                    //For POD
                    response.POSizeDBo.PODBo = new PODBo();
                    response.POSizeDBo.PODBo.ID = POSizeD.POD.ID;

                    //For ColorInfo
                    response.POSizeDBo.ColorInfoBo = new ColorInfoBo();
                    response.POSizeDBo.ColorInfoBo.ID = POSizeD.ColorInfo.ID;
                    response.POSizeDBo.ColorInfoBo.ColorCode = POSizeD.ColorInfo.ColorCode;
                    response.POSizeDBo.ColorInfoBo.ColorName = POSizeD.ColorInfo.ColorName;


                    response.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    response.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (Exception e)
            {
                response.DtoStatus = DtoStatus.Error;
                response.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return response;
        }
        #endregion POSizeD
    }
}
