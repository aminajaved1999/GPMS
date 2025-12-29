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
                if (pPOMBo.ShipmentTermID <= 0)
                {
                    throw new UserException("Please provide a valid Shipping Term ID.");
                }
                if (pPOMBo.POFromID <= 0)
                {
                    throw new UserException("Please provide a valid PO From ID.");
                }
                if (pPOMBo.POTypeID <= 0)
                {
                    throw new UserException("Please provide a valid PO Type ID.");
                }
                if (pPOMBo.POLevelID <= 0)
                {
                    throw new UserException("Please provide a valid PO Level ID.");
                }
                if (pPOMBo.PackingTypeID <= 0)
                {
                    throw new UserException("Please provide a valid Packing Type ID.");
                }
                if (pPOMBo.POStatus == null)
                {
                    throw new UserException("Please provide a valid PO Status");
                }
                if (pPOMBo.CreatedByID == null)
                {
                    throw new UserException("CreatedByID can't be null.");
                }
                // validate

                POM.CustomerID = pPOMBo.CustomerID;
                POM.PONo = pPOMBo.PONo;
                POM.OriginalPONo = pPOMBo.OriginalPONo;
                POM.POReceivedDate = pPOMBo.POReceivedDate;
                POM.PaymentModeID = pPOMBo.PaymentModeID;
                POM.TermID = pPOMBo.TermID;
                POM.ShippingMethodID = pPOMBo.ShippingMethodID;
                POM.ShipmentTermID = pPOMBo.ShipmentTermID;
                POM.POFromID = pPOMBo.POFromID;
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
                POM.CreatedByID = pPOMBo.CreatedByID;
                POM.CreatedAt = DateTime.Now;
                POM.Notes = pPOMBo.Notes;
                POM.UpdatedCount = 0;

                EntitiesContext.POMs.Add(POM);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pPOMBo.CreatedByID.Value);
                    response.DtoStatus = DtoStatus.Success;
                    response.POMBo = new POMBo();
                    response.POMBo.ID = POM.ID;
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
            CommonManager commonManager = new CommonManager();
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
                if (pPOMBo.ShipmentTermID <= 0)
                {
                    throw new UserException("Please provide a valid Shipping Term ID.");
                }
                if (pPOMBo.POFromID <= 0)
                {
                    throw new UserException("Please provide a valid PO From ID.");
                }
                if (pPOMBo.POTypeID <= 0)
                {
                    throw new UserException("Please provide a valid PO Type ID.");
                }
                if (pPOMBo.POLevelID <= 0)
                {
                    throw new UserException("Please provide a valid PO Level ID.");
                }
                if (pPOMBo.PackingTypeID <= 0)
                {
                    throw new UserException("Please provide a valid Packing Type ID.");
                }
                if (pPOMBo.POStatus == null)
                {
                    throw new UserException("Please provide a valid PO Status");
                }
                if (pPOMBo.UpdatedByID == null)
                {
                    throw new UserException("UpdatedByID can't be null.");
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
                    retPOM.POFromID = pPOMBo.POFromID;
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
                    retPOM.UpdatedBy = pPOMBo.UpdatedBy;
                    retPOM.UpdatedByID = pPOMBo.UpdatedByID;
                    retPOM.UpdatedAt = DateTime.Now;
                    retPOM.UpdatedCount = commonManager.IncrementUpdatedCount(retPOM.UpdatedCount);
                    retPOM.Notes = pPOMBo.Notes;

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pPOMBo.UpdatedByID.Value);
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
                if (pPOMId <= 0)
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
                    res.POMBo.POFromID = pom.POFromID;
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
                    res.POMBo.ApprovedStatus = pom.ApprovedStatus;
                    res.POMBo.ApprovedAt = pom.ApprovedAt;

                    res.POMBo.PODCollection = new List<PODBo>();
                    foreach (var pod in pom.PODs)
                    {
                        PODBo pODBo = new PODBo();
                        pODBo.ID = pod.ID;
                        pODBo.POMID = pod.POMID;
                        pODBo.StyleID = pod.StyleID;
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


                        //For StyleInfo
                        pODBo.StyleInfoBo = new StyleInfoBo();
                        pODBo.StyleInfoBo.ID = pod.StyleInfo.ID;
                        pODBo.StyleInfoBo.StyleCode = pod.StyleInfo.StyleCode;
                        pODBo.StyleInfoBo.StyleName = pod.StyleInfo.StyleName;

                        //For POSizeD
                        pODBo.POSizeDCollection = new List<POSizeDBo>();
                        foreach (var pOSizeD in pod.POSizeDs)
                        {
                            POSizeDBo POSizeDBo = new POSizeDBo();
                            POSizeDBo.ID = pOSizeD.ID;
                            POSizeDBo.PODID = pOSizeD.PODID;
                            POSizeDBo.ColorID = pOSizeD.ColorID;
                            POSizeDBo.SizeID = pOSizeD.SizeID;
                            POSizeDBo.Qty = pOSizeD.Qty;
                            POSizeDBo.Price = pOSizeD.Price;
                            POSizeDBo.Description = pOSizeD.Description;
                            POSizeDBo.CreatedBy = pOSizeD.CreatedBy;
                            POSizeDBo.CreatedAt = pOSizeD.CreatedAt;
                            POSizeDBo.UpdatedBy = pOSizeD.UpdatedBy;
                            POSizeDBo.UpdatedAt = pOSizeD.UpdatedAt;
                            POSizeDBo.UpdatedCount = pOSizeD.UpdatedCount;
                            POSizeDBo.Notes = pOSizeD.Notes;
                            POSizeDBo.ComboCode = pOSizeD.ComboCode;
                            POSizeDBo.IsPilotRun = pOSizeD.IsPilotRun;

                            //For POD
                            POSizeDBo.PODBo = new PODBo();
                            POSizeDBo.PODBo.ID = pOSizeD.POD.ID;
                            //

                            //For ColorInfo
                            POSizeDBo.ColorInfoBo = new ColorInfoBo();
                            POSizeDBo.ColorInfoBo.ID = pOSizeD.ColorInfo.ID;
                            POSizeDBo.ColorInfoBo.ColorCode = pOSizeD.ColorInfo.ColorCode;
                            POSizeDBo.ColorInfoBo.ColorName = pOSizeD.ColorInfo.ColorName;
                            //

                            //For SizeInfo
                            POSizeDBo.SizeInfoBo = new SizeInfoBo();
                            POSizeDBo.SizeInfoBo.ID = pOSizeD.SizeInfo.ID;
                            POSizeDBo.SizeInfoBo.SizeCode = pOSizeD.SizeInfo.SizeCode;
                            POSizeDBo.SizeInfoBo.SizeName = pOSizeD.SizeInfo.SizeName;
                            //
                            pODBo.POSizeDCollection.Add(POSizeDBo);
                        }

                        res.POMBo.PODCollection.Add(pODBo);
                    }
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
                    res.POMBo.POFormBo = new POFromBo();
                    res.POMBo.POFormBo.ID = pom.POFrom.ID;
                    res.POMBo.POFormBo.POFromCode = pom.POFrom.POFromCode;
                    res.POMBo.POFormBo.POFromName = pom.POFrom.POFromName;

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
                    response.POMBo.POFromID = pom.POFromID;
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
                    response.POMBo.ApprovedStatus = pom.ApprovedStatus;
                    response.POMBo.ApprovedAt = pom.ApprovedAt;

                    response.POMBo.PODCollection = new List<PODBo>();
                    foreach (var pod in pom.PODs)
                    {
                        PODBo pODBo = new PODBo();
                        pODBo.ID = pod.ID;
                        pODBo.POMID = pod.POMID;
                        pODBo.StyleID = pod.StyleID;
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


                        //For StyleInfo
                        pODBo.StyleInfoBo = new StyleInfoBo();
                        pODBo.StyleInfoBo.ID = pod.StyleInfo.ID;
                        pODBo.StyleInfoBo.StyleCode = pod.StyleInfo.StyleCode;
                        pODBo.StyleInfoBo.StyleName = pod.StyleInfo.StyleName;

                        //For POSizeD
                        pODBo.POSizeDCollection = new List<POSizeDBo>();
                        foreach (var pOSizeD in pod.POSizeDs)
                        {
                            POSizeDBo POSizeDBo = new POSizeDBo();
                            POSizeDBo.ID = pOSizeD.ID;
                            POSizeDBo.PODID = pOSizeD.PODID;
                            POSizeDBo.ColorID = pOSizeD.ColorID;
                            POSizeDBo.SizeID = pOSizeD.SizeID;
                            POSizeDBo.Qty = pOSizeD.Qty;
                            POSizeDBo.Price = pOSizeD.Price;
                            POSizeDBo.Description = pOSizeD.Description;
                            POSizeDBo.CreatedBy = pOSizeD.CreatedBy;
                            POSizeDBo.CreatedAt = pOSizeD.CreatedAt;
                            POSizeDBo.UpdatedBy = pOSizeD.UpdatedBy;
                            POSizeDBo.UpdatedAt = pOSizeD.UpdatedAt;
                            POSizeDBo.UpdatedCount = pOSizeD.UpdatedCount;
                            POSizeDBo.Notes = pOSizeD.Notes;
                            POSizeDBo.ComboCode = pOSizeD.ComboCode;
                            POSizeDBo.IsPilotRun = pOSizeD.IsPilotRun;
                            POSizeDBo.ItemNo = pOSizeD.ItemNo;


                            //For POD
                            POSizeDBo.PODBo = new PODBo();
                            POSizeDBo.PODBo.ID = pOSizeD.POD.ID;
                            //

                            //For ColorInfo
                            POSizeDBo.ColorInfoBo = new ColorInfoBo();
                            POSizeDBo.ColorInfoBo.ID = pOSizeD.ColorInfo.ID;
                            POSizeDBo.ColorInfoBo.ColorCode = pOSizeD.ColorInfo.ColorCode;
                            POSizeDBo.ColorInfoBo.ColorName = pOSizeD.ColorInfo.ColorName;
                            //

                            //For SizeInfo
                            POSizeDBo.SizeInfoBo = new SizeInfoBo();
                            POSizeDBo.SizeInfoBo.ID = pOSizeD.SizeInfo.ID;
                            POSizeDBo.SizeInfoBo.SizeCode = pOSizeD.SizeInfo.SizeCode;
                            POSizeDBo.SizeInfoBo.SizeName = pOSizeD.SizeInfo.SizeName;
                            //
                            pODBo.POSizeDCollection.Add(POSizeDBo);
                        }

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
                    response.POMBo.POFormBo = new POFromBo();
                    response.POMBo.POFormBo.ID = pom.POFrom.ID;
                    response.POMBo.POFormBo.POFromCode = pom.POFrom.POFromCode;
                    response.POMBo.POFormBo.POFromName = pom.POFrom.POFromName;

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

        public OrderDto DeletePOM(int id, int? userid)
        {
            CommonManager commonManager = new CommonManager();
            var res = new OrderDto();
            try
            {
                // validate
                if (id <= 0)
                {
                    throw new UserException("Please provide valid POM ID.");
                }
                if (userid == null)
                {
                    throw new UserException("userid can't be null.");
                }
                // validate

                var retPOM = EntitiesContext.POMs.FirstOrDefault(x => x.ID == id);
                if (retPOM != null)
                {
                    EntitiesContext.POMs.Remove(retPOM);
                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, userid.Value);
                        res.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
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

        public ValidationDto IsPONumberExist(string pPoNo)
        {
            var validationDto = new ValidationDto();

            try
            {
                //validate
                if (pPoNo == null)
                {
                    throw new UserException("Please provide a valid PO No.");
                }
                //validate

                bool pPoNoExists = EntitiesContext.POMs.Any(x => x.PONo == pPoNo);

                if (pPoNoExists)
                {
                    validationDto.DtoStatus = DtoStatus.Success;
                    validationDto.IsExist = true;
                }
                else
                {
                    validationDto.DtoStatus = DtoStatus.NoDataFound;
                    validationDto.IsExist = false;
                }
            }
            catch (Exception e)
            {
                validationDto.DtoStatus = DtoStatus.Error;
                validationDto.DtoStatusNotes.Exception = e.Message.ToString();
            }

            return validationDto;
        }



        #endregion POM

        #region POD
        /// <summary>
        /// Add new POD.
        /// </summary>
        /// <param name="pPODBo"></param>
        /// <returns></returns>
        public OrderDto AddPOD(List<PODBo> pPODBoList)
        {
            OrderDto response = new OrderDto();

            try
            {
                foreach (var pPODBo in pPODBoList)
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
                    if (pPODBo.CreatedByID == null)
                    {
                        throw new UserException("CreatedByID can't be null");
                    }
                    // validate

                    POD.POMID = pPODBo.POMID;
                    POD.StyleID = pPODBo.StyleID;
                    POD.Description = pPODBo.Description;
                    POD.CreatedBy = pPODBo.CreatedBy;
                    POD.CreatedByID = pPODBo.CreatedByID;
                    POD.CreatedAt = DateTime.Now;
                    POD.Notes = pPODBo.Notes;
                    POD.UpdatedCount = 0;
                    EntitiesContext.PODs.Add(POD);

                }

                if (EntitiesContext.SaveChanges() > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pPODBoList.FirstOrDefault().CreatedByID.Value);
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
            CommonManager commonManager = new CommonManager();
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
                if (pPODBo.UpdatedByID == null)
                {
                    throw new UserException("UpdatedByID can't be null");
                }
                // validate

                var retPOD = EntitiesContext.PODs.Where(x => x.ID == pPODBo.ID).FirstOrDefault();
                if (retPOD != null)
                {
                    retPOD.ID = pPODBo.ID;
                    retPOD.POMID = pPODBo.POMID;
                    retPOD.StyleID = pPODBo.StyleID;
                    retPOD.Description = pPODBo.Description;
                    retPOD.UpdatedBy = pPODBo.UpdatedBy;
                    retPOD.UpdatedByID = pPODBo.UpdatedByID;
                    retPOD.UpdatedAt = DateTime.Now;
                    retPOD.UpdatedCount = commonManager.IncrementUpdatedCount(retPOD.UpdatedCount);
                    retPOD.Notes = pPODBo.Notes;

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pPODBo.UpdatedByID.Value);
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

        public OrderDto AddUpdatePOD(List<PODBo> pPODBoList)
        {
            CommonManager commonManager = new CommonManager();
            OrderDto response = new OrderDto();
            bool add = false;
            try
            {
                //validate
                if (pPODBoList == null || pPODBoList.Count == 0)
                {
                    throw new UserException("Input list is null or empty.");
                }

                foreach (var pPODBo in pPODBoList)
                {
                    if (pPODBo.POMID <= 0)
                    {
                        throw new UserException("Please provide a valid POM ID.");
                    }
                    if (pPODBo.StyleID <= 0)
                    {
                        throw new UserException("Please provide a valid Style ID");
                    }
                }
                //validate
                int? userid = 0;

                foreach (var pPODBo in pPODBoList)
                {
                    if (pPODBo.ID <= 0)
                    {
                        if (pPODBo.CreatedByID == null)
                        {
                            throw new UserException("CreatedByID can't be null");
                        }

                        add = true;
                        // Add new POD
                        POD newPOD = new POD();
                        newPOD.POMID = pPODBo.POMID;
                        newPOD.StyleID = pPODBo.StyleID;
                        newPOD.Description = pPODBo.Description;
                        newPOD.CreatedBy = pPODBo.CreatedBy;
                        userid = newPOD.CreatedByID = pPODBo.CreatedByID;
                        newPOD.CreatedAt = DateTime.Now;
                        newPOD.Notes = pPODBo.Notes;
                        newPOD.UpdatedCount = 0;

                        EntitiesContext.PODs.Add(newPOD);
                    }
                    else
                    {
                        if (pPODBo.UpdatedByID == null)
                        {
                            throw new UserException("UpdatedByID can't be null");
                        }

                        // Update existing POD
                        var existingPOD = EntitiesContext.PODs.Where(x => x.ID == pPODBo.ID).FirstOrDefault();
                        if (existingPOD != null)
                        {
                            existingPOD.POMID = pPODBo.POMID;
                            existingPOD.StyleID = pPODBo.StyleID;
                            existingPOD.Description = pPODBo.Description;
                            existingPOD.Notes = pPODBo.Notes;
                            existingPOD.UpdatedAt = DateTime.Now;
                            existingPOD.UpdatedBy = pPODBo.UpdatedBy;
                            userid = existingPOD.UpdatedByID = pPODBo.UpdatedByID;
                            existingPOD.UpdatedCount = commonManager.IncrementUpdatedCount(existingPOD.UpdatedCount);
                        }
                        else
                        {
                            response.DtoStatus = DtoStatus.NoDataFound;
                        }
                    }

                }

                var SaveChanges = EntitiesContext.SaveChanges();

                if (SaveChanges > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, userid.Value);
                    response.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    if (add)
                    {
                        response.DtoStatus = DtoStatus.RecordNotAdded;
                        response.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                    }
                    else
                    {
                        if (SaveChanges <= 0)
                        {
                            response.DtoStatus = DtoStatus.RecordNotUpdatedWithoutChanges;
                        }
                        else
                        {
                            response.DtoStatus = DtoStatus.RecordNotUpdated;
                        }
                    }

                }

            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        response.DtoStatus = DtoStatus.Error;
                        response.DtoStatusNotes.Exception = sqlEx.Message.ToString();
                    }
                    else
                    {
                        response.DtoStatus = DtoStatus.Error;
                        response.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    response.DtoStatus = DtoStatus.Error;
                    response.DtoStatusNotes.Exception = db.Message.ToString();
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
                if (pPODId <= 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var poD = EntitiesContext.PODs.Where(x => x.ID == pPODId).FirstOrDefault();
                if (poD != null)
                {
                    res.PODBo = new PODBo();
                    res.PODBo.ID = poD.ID;
                    res.PODBo.POMID = poD.POMID;
                    res.PODBo.StyleID = poD.StyleID;
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

        public OrderDto DeletePOD(int id, int? userid)
        {
            CommonManager commonManager = new CommonManager();
            var res = new OrderDto();
            try
            {
                // validate
                if (id <= 0)
                {
                    throw new UserException("Please provide valid POD ID.");
                }
                if (userid == null)
                {
                    throw new UserException("userid can't be null.");
                }
                // validate

                var retPOD = EntitiesContext.PODs.FirstOrDefault(x => x.ID == id);
                if (retPOD != null)
                {
                    EntitiesContext.PODs.Remove(retPOD);
                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, userid.Value);
                        res.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
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

        #endregion POD

        #region POSizeD
        /// <summary>
        /// Add new POSizeD.
        /// </summary>
        /// <param name="pPOSizeDBo"></param>
        /// <returns></returns>
        public OrderDto AddPOSizeD(List<POSizeDBo> pPOSizeDBoList)
        {
            OrderDto response = new OrderDto();

            try
            {
                foreach (var pPOSizeDBo in pPOSizeDBoList)
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
                    if (pPOSizeDBo.CreatedByID == null)
                    {
                        throw new UserException("CreatedByID can't be null");
                    }
                    if (pPOSizeDBo.ItemNo == null)
                    {
                        throw new UserException("Please provide a valid ItemNo");
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
                    POSizeD.CreatedByID = pPOSizeDBo.CreatedByID;
                    POSizeD.CreatedAt = DateTime.Now;
                    POSizeD.UpdatedCount = 0;
                    POSizeD.Notes = pPOSizeDBo.Notes;
                    POSizeD.ComboCode = pPOSizeDBo.ComboCode;
                    POSizeD.IsPilotRun = pPOSizeDBo.IsPilotRun;
                    POSizeD.ItemNo = pPOSizeDBo.ItemNo;

                    EntitiesContext.POSizeDs.Add(POSizeD);
                }
                if (EntitiesContext.SaveChanges() > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pPOSizeDBoList.FirstOrDefault().CreatedByID.Value);
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
            CommonManager commonManager = new CommonManager();
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
                if (pPOSizeDBo.UpdatedByID == null)
                {
                    throw new UserException("UpdatedByID can't be null");
                }
                if (pPOSizeDBo.ItemNo == null)
                {
                    throw new UserException("Please provide a valid ItemNo");
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
                    retPOSizeD.UpdatedBy = pPOSizeDBo.UpdatedBy;
                    retPOSizeD.UpdatedByID = pPOSizeDBo.UpdatedByID;
                    retPOSizeD.UpdatedAt = DateTime.Now;
                    retPOSizeD.UpdatedCount = commonManager.IncrementUpdatedCount(retPOSizeD.UpdatedCount);
                    retPOSizeD.Notes = pPOSizeDBo.Notes;
                    retPOSizeD.ComboCode = pPOSizeDBo.ComboCode;
                    retPOSizeD.IsPilotRun = pPOSizeDBo.IsPilotRun;
                    retPOSizeD.ItemNo = pPOSizeDBo.ItemNo;

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pPOSizeDBo.CreatedByID.Value);
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
                if (pPOSizeDId <= 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                // validate

                response.DtoStatus = DtoStatus.Failed;
                var POSizeD = EntitiesContext.POSizeDs.Where(x => x.ID == pPOSizeDId).FirstOrDefault();
                if (POSizeD != null)
                {
                    response.POSizeDBo = new POSizeDBo();
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
                    response.POSizeDBo.ComboCode = POSizeD.ComboCode;
                    response.POSizeDBo.IsPilotRun = POSizeD.IsPilotRun;
                    response.POSizeDBo.ItemNo = POSizeD.ItemNo;

                    //For POD
                    response.POSizeDBo.PODBo = new PODBo();
                    response.POSizeDBo.PODBo.ID = POSizeD.POD.ID;

                    //For ColorInfo
                    response.POSizeDBo.ColorInfoBo = new ColorInfoBo();
                    response.POSizeDBo.ColorInfoBo.ID = POSizeD.ColorInfo.ID;
                    response.POSizeDBo.ColorInfoBo.ColorCode = POSizeD.ColorInfo.ColorCode;
                    response.POSizeDBo.ColorInfoBo.ColorName = POSizeD.ColorInfo.ColorName;

                    //For SizeInfo
                    response.POSizeDBo.SizeInfoBo = new SizeInfoBo();
                    response.POSizeDBo.SizeInfoBo.ID = POSizeD.SizeInfo.ID;
                    response.POSizeDBo.SizeInfoBo.SizeCode = POSizeD.SizeInfo.SizeCode;
                    response.POSizeDBo.SizeInfoBo.SizeName = POSizeD.SizeInfo.SizeName;


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

        /// <summary>
        /// Add new or update existing POSizeD objects.
        /// </summary>
        /// <param name="pPOSizeDList"></param>
        /// <returns></returns>
        public OrderDto AddUpdatePOSizeD(List<POSizeDBo> pPOSizeDBoList)
        {
            CommonManager commonManager = new CommonManager();
            OrderDto response = new OrderDto();
            bool add = false;
            try
            {
                //validate
                if (pPOSizeDBoList == null || pPOSizeDBoList.Count == 0)
                {
                    throw new UserException("Input list is null or empty.");
                }

                foreach (var pPOSizeDBo in pPOSizeDBoList)
                {
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
                    if (pPOSizeDBo.ItemNo == null)
                    {
                        throw new UserException("Please provide a valid ItemNo");
                    }
                }
                //validate
                int? userid = 0;
                foreach (var pPOSizeDBo in pPOSizeDBoList)
                {
                    if (pPOSizeDBo.ID <= 0)
                    {
                        if (pPOSizeDBo.CreatedByID == null)
                        {
                            throw new UserException("CreatedByID can't be null");
                        }

                        add = true;
                        // Add new POSizeD
                        POSizeD newPOSizeD = new POSizeD();
                        newPOSizeD.PODID = pPOSizeDBo.PODID;
                        newPOSizeD.ColorID = pPOSizeDBo.ColorID;
                        newPOSizeD.SizeID = pPOSizeDBo.SizeID;
                        newPOSizeD.Qty = pPOSizeDBo.Qty;
                        newPOSizeD.Price = pPOSizeDBo.Price;
                        newPOSizeD.Description = pPOSizeDBo.Description;
                        newPOSizeD.CreatedBy = pPOSizeDBo.CreatedBy;
                        userid = newPOSizeD.CreatedByID = pPOSizeDBo.CreatedByID;
                        newPOSizeD.CreatedAt = DateTime.Now;
                        newPOSizeD.UpdatedCount = 0;
                        newPOSizeD.Notes = pPOSizeDBo.Notes;
                        newPOSizeD.ComboCode = pPOSizeDBo.ComboCode;
                        newPOSizeD.IsPilotRun = pPOSizeDBo.IsPilotRun;
                        newPOSizeD.ItemNo = pPOSizeDBo.ItemNo;

                        EntitiesContext.POSizeDs.Add(newPOSizeD);
                    }
                    else
                    {


                        // Update existing POSizeD
                        var existingPOSizeD = EntitiesContext.POSizeDs.Where(x => x.ID == pPOSizeDBo.ID).FirstOrDefault();
                        if (existingPOSizeD != null)
                        {
                            if (pPOSizeDBo.UpdatedByID == null)
                            {
                                throw new UserException("UpdatedByID can't be null");
                            }

                            existingPOSizeD.ID = pPOSizeDBo.ID;
                            existingPOSizeD.PODID = pPOSizeDBo.PODID;
                            existingPOSizeD.ColorID = pPOSizeDBo.ColorID;
                            existingPOSizeD.SizeID = pPOSizeDBo.SizeID;
                            existingPOSizeD.Qty = pPOSizeDBo.Qty;
                            existingPOSizeD.Price = pPOSizeDBo.Price;
                            existingPOSizeD.Description = pPOSizeDBo.Description;
                            existingPOSizeD.UpdatedAt = DateTime.Now;
                            existingPOSizeD.UpdatedBy = pPOSizeDBo.UpdatedBy;
                            userid = existingPOSizeD.UpdatedByID = pPOSizeDBo.UpdatedByID;
                            existingPOSizeD.UpdatedCount = commonManager.IncrementUpdatedCount(existingPOSizeD.UpdatedCount);
                            existingPOSizeD.Notes = pPOSizeDBo.Notes;
                            existingPOSizeD.ComboCode = pPOSizeDBo.ComboCode;
                            existingPOSizeD.IsPilotRun = pPOSizeDBo.IsPilotRun;
                            existingPOSizeD.ItemNo = pPOSizeDBo.ItemNo;
                        }
                        else
                        {
                            response.DtoStatus = DtoStatus.NoDataFound;
                        }
                    }

                }

                var SaveChanges = EntitiesContext.SaveChanges();

                if (SaveChanges > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, userid.Value);
                    response.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    if (add)
                    {
                        response.DtoStatus = DtoStatus.RecordNotAdded;
                        response.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                    }
                    else
                    {
                        if (SaveChanges <= 0)
                        {
                            response.DtoStatus = DtoStatus.RecordNotUpdatedWithoutChanges;
                        }
                        else
                        {
                            response.DtoStatus = DtoStatus.RecordNotUpdated;
                        }
                    }

                }

            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        response.DtoStatus = DtoStatus.Error;
                        response.DtoStatusNotes.Exception = sqlEx.Message.ToString();
                    }
                    else
                    {
                        response.DtoStatus = DtoStatus.Error;
                        response.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    response.DtoStatus = DtoStatus.Error;
                    response.DtoStatusNotes.Exception = db.Message.ToString();
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

        public OrderDto DeletePOSizeD(int id, int? userid)
        {
            CommonManager commonManager = new CommonManager();
            var res = new OrderDto();
            try
            {
                // validate
                if (id <= 0)
                {
                    throw new UserException("Please provide valid POSizeD ID.");
                }
                if (userid == null)
                {
                    throw new UserException("userid can't be null.");
                }
                // validate

                var retPOSizeD = EntitiesContext.POSizeDs.FirstOrDefault(x => x.ID == id);
                if (retPOSizeD != null)
                {
                    EntitiesContext.POSizeDs.Remove(retPOSizeD);
                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, userid.Value);
                        res.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
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

        public OrderDto DeletePOSizeDCollection(List<int> pPOSizeDIDs, int? userid)
        {
            CommonManager commonManager = new CommonManager();
            var res = new OrderDto();
            try
            {
                foreach (var id in pPOSizeDIDs)
                {
                    if (id <= 0)
                    {
                        throw new UserException("Please provide valid POSizeD ID.");
                    }
                }

                if (userid == null)
                {
                    throw new UserException("userid can't be null.");
                }

                var retPOSizeD = EntitiesContext.POSizeDs.Where(x => pPOSizeDIDs.Contains(x.ID)).ToList();
                if (retPOSizeD != null && retPOSizeD.Count > 0)
                {
                    EntitiesContext.POSizeDs.RemoveRange(retPOSizeD);
                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, userid.Value);
                        res.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
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

        public ValidationDto IsItemExistInPO(string PONo, string ItemNo)
        {
            var validationDto = new ValidationDto();
            try
            {
                //validate
                if (PONo == null)
                {
                    throw new UserException("Please provide a valid PO No.");
                }
                if (ItemNo == null)
                {
                    throw new UserException("Please provide a valid Item No.");
                }
                //validate

                var itemExists = (
                               from poSizeD in EntitiesContext.POSizeDs
                               join poD in EntitiesContext.PODs on poSizeD.PODID equals poD.ID
                               join poM in EntitiesContext.POMs on poD.POMID equals poM.ID
                               where poM.PONo == PONo && poSizeD.ItemNo == ItemNo
                               select poSizeD
                            ).Any();

                if (itemExists)
                {
                    validationDto.DtoStatus = DtoStatus.Success;
                    validationDto.IsExist = true;
                }
                else
                {
                    validationDto.DtoStatus = DtoStatus.NoDataFound;
                    validationDto.IsExist = false;

                }
            }
            catch (UserException ux)
            {
                validationDto.DtoStatus = DtoStatus.Error;
                validationDto.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                validationDto.DtoStatus = DtoStatus.Error;
                validationDto.DtoStatusNotes.Exception = e.Message.ToString();
            }

            return validationDto;
        }


        public ValidationDto IsPackQtyValid(int pCustomerID, string PONo, string ItemNo, int CurrentPackQty)
        {
            var validationDto = new ValidationDto();
            try
            {
                //validate
                if (pCustomerID <= 0)
                {
                    throw new UserException("Please provide a valid CustomerID.");
                }
                if (PONo == null)
                {
                    throw new UserException("Please provide a valid PO No.");
                }
                if (ItemNo == null)
                {
                    throw new UserException("Please provide a valid Item No.");
                }
                if (CurrentPackQty < 0)
                {
                    throw new UserException("Current Pack Qty can't be negative(-ve).");
                }
                //validate

                // get order qty
                var orderQty = (from poSizeD in EntitiesContext.POSizeDs
                                   join poD in EntitiesContext.PODs on poSizeD.PODID equals poD.ID
                                   join poM in EntitiesContext.POMs on poD.POMID equals poM.ID
                                   where poM.PONo == PONo && poM.CustomerID == pCustomerID && poSizeD.ItemNo == ItemNo
                                   select poSizeD.Qty).ToList().Sum();
                if (orderQty <= 0)
                    throw new UserException("Order Qty can't be Zero(0) or negative(-ve).");

                // get all packing inst. ids
                var packInstMIDs = (from packInstM in EntitiesContext.PackingInstructionMs
                                    where packInstM.PONo == PONo
                                    select packInstM.ID).ToList();
                
                // get already processed qty
                var processedPackQty = (from packInstM in EntitiesContext.PackingInstructionMs
                                         join packInstD in EntitiesContext.PackingInstructionDs on packInstM.ID equals packInstD.PackingInstructionMID
                                         where packInstM.CustomerID == pCustomerID && packInstD.ItemNo == ItemNo
                                         && packInstMIDs.Contains(packInstD.PackingInstructionMID)
                                         select packInstD.ItemQtyPerCase).ToList().Sum();

                if (!processedPackQty.HasValue)
                    processedPackQty = 0;
               
                if (orderQty < (processedPackQty + CurrentPackQty))
                {
                    validationDto.IsExist = false;
                    validationDto.DtoStatusNotes.ExtraNotes[0] = "Packing qty can't be greater from PO qty.";
                }
                else
                {
                    validationDto.IsExist = true;
                }

                validationDto.DtoStatus = DtoStatus.Success;
                 
            }
            catch (UserException ux)
            {
                validationDto.DtoStatus = DtoStatus.Error;
                validationDto.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                validationDto.DtoStatus = DtoStatus.Error;
                validationDto.DtoStatusNotes.Exception = e.Message.ToString();
            }

            return validationDto;
        }

        public OrderDto GetItemNo(int pCustomerID, int pStyleID, int pColorID, int pSizeID)
        {
            var orderDto = new OrderDto();
            try
            {
               
                //validate
                if (pCustomerID <= 0)
                {
                    throw new UserException("Please provide a valid CustomerID.");
                }
                if (pStyleID <= 0)
                {
                    throw new UserException("Please provide a valid Style ID.");
                }
                if (pColorID <= 0)
                {
                    throw new UserException("Please provide a valid Color ID.");
                }
                if (pSizeID <= 0)
                {
                    throw new UserException("Please provide a valid Size ID.");
                }
                //validate

                var distinctItemNos = (from poSizeD in EntitiesContext.POSizeDs
                            join poD in EntitiesContext.PODs on poSizeD.PODID equals poD.ID
                            join poM in EntitiesContext.POMs on poD.POMID equals poM.ID
                            where poM.CustomerID == pCustomerID
                                  && poD.StyleID == pStyleID
                                  && poSizeD.ColorID == pColorID
                                  && poSizeD.SizeID == pSizeID
                            select poSizeD.ItemNo).Distinct().ToList();

                if (distinctItemNos.Count > 1)
                {
                    throw new UserException("More than one distinct ItemNo found.");
                }
                else if (distinctItemNos.Count == 1)
                {
                    orderDto.DtoStatus = DtoStatus.Success;
                    orderDto.POSizeDBo = new POSizeDBo();
                    orderDto.POSizeDBo.ItemNo = distinctItemNos.First();
                }
                else
                {
                    orderDto.DtoStatus = DtoStatus.NoDataFound;
                    orderDto.DtoStatusNotes.Exception = "No distinct ItemNo found.";
                }

            }
            catch (UserException ux)
            {
                orderDto.DtoStatus = DtoStatus.Error;
                orderDto.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                orderDto.DtoStatus = DtoStatus.Error;
                orderDto.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return orderDto;
        }

        #endregion POSizeD

        public OrderDto UpdatePOApprovedStatus(POApprovalStatusBo POApprovalStatuBo)
        {
            if (POApprovalStatuBo.POMID <= 0)
            {
                throw new UserException("Please provide a valid pom ID.");
            }
            if (POApprovalStatuBo.Status == null || POApprovalStatuBo.Status.Length > 1)
            {
                throw new UserException("ApprovedStatus must be a string or array type with a maximum length of '1'.");
            }

            CommonManager commonManager = new CommonManager();
            var res = new OrderDto();
            try
            {
                var retPOM = EntitiesContext.POMs.FirstOrDefault(x => x.ID == POApprovalStatuBo.POMID);
                if (retPOM != null)
                {
                    // Adds a new POApprovalStatus
                    POApprovalStatu pOApprovalStatus = new POApprovalStatu();
                    pOApprovalStatus.POMID = POApprovalStatuBo.POMID;
                    pOApprovalStatus.Status = POApprovalStatuBo.Status;
                    pOApprovalStatus.StatusAt = DateTime.Now;
                    pOApprovalStatus.StatusByID = POApprovalStatuBo.StatusByID;
                    pOApprovalStatus.StatusBy = POApprovalStatuBo.StatusBy;

                    EntitiesContext.POApprovalStatus.Add(pOApprovalStatus);

                    if (EntitiesContext.SaveChanges() > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, POApprovalStatuBo.StatusByID.Value);

                        // update POM
                        retPOM.ApprovedStatus = POApprovalStatuBo.Status;
                        retPOM.ApprovedAt = DateTime.Now;

                        EntitiesContext.SaveChanges();
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, POApprovalStatuBo.StatusByID.Value);

                        res.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.RecordNotAdded;
                        res.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
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
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }



    }
}
