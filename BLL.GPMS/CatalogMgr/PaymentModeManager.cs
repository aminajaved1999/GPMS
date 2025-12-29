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
    public class PaymentModeManager : DbBase
    {
        /// <summary>
        /// Add new Payment Mode.
        /// </summary>
        /// <param name="pPaymentModeInfoBo"></param>
        /// <returns></returns>
        public CatalogDto AddPaymentMode(PaymentModeInfoBo pPaymentModeInfoBo)
        {
            var resCatalogDto = new CatalogDto();
            try
            {
                PaymentModeInfo paymentModeInfo = new PaymentModeInfo();

                // validate
                if (pPaymentModeInfoBo.PaymentModeCode == null)
                {
                    throw new UserException("Please provide a valid Payment Mode Code.");
                }
                if (pPaymentModeInfoBo.PaymentModeName == null)
                {
                    throw new UserException("Please provide a valid Payment Mode Name.");
                }
                if (pPaymentModeInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                if (pPaymentModeInfoBo.PaymentModeCode.Length > 10)
                {
                    throw new UserException("The field PaymentModeCode must be a string or array type with a maximum length of '10'.");
                }
                if (pPaymentModeInfoBo.CreatedByID == null)
                {
                    throw new UserException("CreatedByID can't be null");
                }
                // validate

                paymentModeInfo.PaymentModeCode = pPaymentModeInfoBo.PaymentModeCode;
                paymentModeInfo.PaymentModeName = pPaymentModeInfoBo.PaymentModeName;
                paymentModeInfo.Days = pPaymentModeInfoBo.Days;
                paymentModeInfo.PenaltyPercentage = pPaymentModeInfoBo.PenaltyPercentage;
                paymentModeInfo.Description = pPaymentModeInfoBo.Description;
                paymentModeInfo.IsActive = pPaymentModeInfoBo.IsActive;
                paymentModeInfo.CreatedBy = pPaymentModeInfoBo.CreatedBy;
                paymentModeInfo.CreatedByID = pPaymentModeInfoBo.CreatedByID;
                paymentModeInfo.CreatedAt = DateTime.Now;
                paymentModeInfo.UpdatedCount = 0;

                EntitiesContext.PaymentModeInfoes.Add(paymentModeInfo);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pPaymentModeInfoBo.CreatedByID.Value);
                    resCatalogDto.DtoStatus = DtoStatus.Success;
                    resCatalogDto.PaymentModeInfoBo = new PaymentModeInfoBo();
                    resCatalogDto.PaymentModeInfoBo.ID = paymentModeInfo.ID;
                }
                else
                {
                    resCatalogDto.DtoStatus = DtoStatus.RecordNotAdded;
                    resCatalogDto.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                }
            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // 2627 mean Violation in unique constraint & 2601 mean duplicate/unique index values
                        {
                            resCatalogDto.DtoStatus = DtoStatus.Error;
                            resCatalogDto.DtoStatusNotes.Exception = "PaymentMode code already exist.";
                            resCatalogDto.DtoStatusNotes.ExtraNotes.Add("Violation in unique constraint");
                        }
                    }
                    else
                    {
                        resCatalogDto.DtoStatus = DtoStatus.Error;
                        resCatalogDto.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    resCatalogDto.DtoStatus = DtoStatus.Error;
                    resCatalogDto.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                resCatalogDto.DtoStatus = DtoStatus.RecordNotAdded;
                resCatalogDto.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                resCatalogDto.DtoStatus = DtoStatus.Error;
                resCatalogDto.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return resCatalogDto;
        }

        /// <summary>
        /// Update existing Payment Mode.
        /// </summary>
        /// <param name="pPaymentModeInfoBo"></param>
        /// <returns></returns>
        public CatalogDto UpdatePaymentMode(PaymentModeInfoBo pPaymentModeInfoBo)
        {
            CommonManager commonManager = new CommonManager();
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPaymentModeInfoBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid ID.");
                }
                if (pPaymentModeInfoBo.PaymentModeCode == null)
                {
                    throw new UserException("Please provide a valid Payment Mode Code.");
                }
                if (pPaymentModeInfoBo.PaymentModeName == null)
                {
                    throw new UserException("Please provide a valid Payment Mode Name.");
                }
                if (pPaymentModeInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                if (pPaymentModeInfoBo.PaymentModeCode.Length > 10)
                {
                    throw new UserException("The field PaymentModeCode must be a string or array type with a maximum length of '10'.");
                }
                if (pPaymentModeInfoBo.UpdatedByID == null)
                {
                    throw new UserException("UpdatedByID can't be null");
                }
                // validate

                var retPaymentMode = EntitiesContext.PaymentModeInfoes.Where(x => x.ID == pPaymentModeInfoBo.ID).FirstOrDefault();
                if (retPaymentMode != null)
                {
                    retPaymentMode.PaymentModeCode = pPaymentModeInfoBo.PaymentModeCode;
                    retPaymentMode.PaymentModeName = pPaymentModeInfoBo.PaymentModeName;
                    retPaymentMode.Days = pPaymentModeInfoBo.Days;
                    retPaymentMode.PenaltyPercentage = pPaymentModeInfoBo.PenaltyPercentage;
                    retPaymentMode.Description = pPaymentModeInfoBo.Description;
                    retPaymentMode.IsActive = pPaymentModeInfoBo.IsActive;
                    retPaymentMode.UpdatedBy = pPaymentModeInfoBo.UpdatedBy;
                    retPaymentMode.UpdatedByID = pPaymentModeInfoBo.UpdatedByID;
                    retPaymentMode.UpdatedAt = DateTime.Now;
                    retPaymentMode.UpdatedCount = commonManager.IncrementUpdatedCount(retPaymentMode.UpdatedCount);

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pPaymentModeInfoBo.UpdatedByID.Value);
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
        /// Get Payment Mode Info against given Payment Mode id.
        /// </summary>
        /// <param name="pPaymentModeId"></param>
        /// <returns></returns>
        public CatalogDto GetPaymentModeById(int pPaymentModeId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPaymentModeId <= 0)
                {
                    throw new UserException("Please provide a valid Payment Mode Id.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var PaymentMode = EntitiesContext.PaymentModeInfoes.Where(x => x.ID == pPaymentModeId).FirstOrDefault();
                if (PaymentMode != null)
                {
                    res.PaymentModeInfoBo = new PaymentModeInfoBo();
                    res.PaymentModeInfoBo.ID = PaymentMode.ID;
                    res.PaymentModeInfoBo.PaymentModeCode = PaymentMode.PaymentModeCode;
                    res.PaymentModeInfoBo.PaymentModeName = PaymentMode.PaymentModeName;
                    res.PaymentModeInfoBo.Days = PaymentMode.Days;
                    res.PaymentModeInfoBo.PenaltyPercentage = PaymentMode.PenaltyPercentage;
                    res.PaymentModeInfoBo.Description = PaymentMode.Description;
                    res.PaymentModeInfoBo.IsActive = PaymentMode.IsActive;
                    res.PaymentModeInfoBo.CreatedBy = PaymentMode.CreatedBy;
                    res.PaymentModeInfoBo.CreatedAt = PaymentMode.CreatedAt;
                    res.PaymentModeInfoBo.UpdatedBy = PaymentMode.UpdatedBy;
                    res.PaymentModeInfoBo.UpdatedAt = PaymentMode.UpdatedAt;
                    res.PaymentModeInfoBo.UpdatedCount = PaymentMode.UpdatedCount;
                    res.PaymentModeInfoBo.Notes = PaymentMode.Notes;

                    //for POM Collection
                    res.PaymentModeInfoBo.POMCollection = new List<POMBo>();
                    foreach (var POM in PaymentMode.POMs)
                    {
                        POMBo POMBo = new POMBo();
                        POMBo.ID = POM.ID;

                        res.PaymentModeInfoBo.POMCollection.Add(POMBo);
                    }
                    //

                    res.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
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
        /// Get Payment Mode Info against given Payment Mode Code.
        /// </summary>
        /// <param name="pPaymentModeCode"></param>
        /// <returns></returns>
        public CatalogDto GetPaymentModeByCode(string pPaymentModeCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPaymentModeCode == null)
                {
                    throw new UserException("Please provide a valid Payment Mode Code.");
                }
                // validate
                res.DtoStatus = DtoStatus.Failed;
                var PaymentMode = EntitiesContext.PaymentModeInfoes.Where(x => x.PaymentModeCode == pPaymentModeCode).FirstOrDefault();
                if (PaymentMode != null)
                {
                    res.PaymentModeInfoBo = new PaymentModeInfoBo();
                    res.PaymentModeInfoBo.ID = PaymentMode.ID;
                    res.PaymentModeInfoBo.PaymentModeCode = PaymentMode.PaymentModeCode;
                    res.PaymentModeInfoBo.PaymentModeName = PaymentMode.PaymentModeName;
                    res.PaymentModeInfoBo.Days = PaymentMode.Days;
                    res.PaymentModeInfoBo.PenaltyPercentage = PaymentMode.PenaltyPercentage;
                    res.PaymentModeInfoBo.Description = PaymentMode.Description;
                    res.PaymentModeInfoBo.IsActive = PaymentMode.IsActive;
                    res.PaymentModeInfoBo.CreatedBy = PaymentMode.CreatedBy;
                    res.PaymentModeInfoBo.CreatedAt = PaymentMode.CreatedAt;
                    res.PaymentModeInfoBo.UpdatedBy = PaymentMode.UpdatedBy;
                    res.PaymentModeInfoBo.UpdatedAt = PaymentMode.UpdatedAt;
                    res.PaymentModeInfoBo.UpdatedCount = PaymentMode.UpdatedCount;
                    res.PaymentModeInfoBo.Notes = PaymentMode.Notes;

                    //for POM Collection
                    res.PaymentModeInfoBo.POMCollection = new List<POMBo>();
                    foreach (var POM in PaymentMode.POMs)
                    {
                        POMBo POMBo = new POMBo();
                        POMBo.ID = POM.ID;

                        res.PaymentModeInfoBo.POMCollection.Add(POMBo);
                    }
                    //

                    res.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
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
        /// To Get all Payment Modes then pass parameter value as 'null'. 
        /// To Get all active Payment Modes then pass parameter value as 'true'. 
        /// To Get all In-active Payment Modes then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllPaymentModes(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<PaymentModeInfo> PaymentModeList;
                if (pIsActive.HasValue)
                    PaymentModeList = EntitiesContext.PaymentModeInfoes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    PaymentModeList = EntitiesContext.PaymentModeInfoes.ToList();

                if (PaymentModeList != null && PaymentModeList.Count > 0)
                {
                    res.PaymentModeInfoCollection = new List<PaymentModeInfoBo>();
                    foreach (var PaymentMode in PaymentModeList)
                    {
                        PaymentModeInfoBo paymentModeInfoBo = new PaymentModeInfoBo();
                        paymentModeInfoBo.ID = PaymentMode.ID;
                        paymentModeInfoBo.PaymentModeCode = PaymentMode.PaymentModeCode;
                        paymentModeInfoBo.PaymentModeName = PaymentMode.PaymentModeName;
                        paymentModeInfoBo.Days = PaymentMode.Days;
                        paymentModeInfoBo.PenaltyPercentage = PaymentMode.PenaltyPercentage;
                        paymentModeInfoBo.Description = PaymentMode.Description;
                        paymentModeInfoBo.IsActive = PaymentMode.IsActive;
                        paymentModeInfoBo.CreatedBy = PaymentMode.CreatedBy;
                        paymentModeInfoBo.CreatedAt = PaymentMode.CreatedAt;
                        paymentModeInfoBo.UpdatedBy = PaymentMode.UpdatedBy;
                        paymentModeInfoBo.UpdatedAt = PaymentMode.UpdatedAt;
                        paymentModeInfoBo.UpdatedCount = PaymentMode.UpdatedCount;
                        paymentModeInfoBo.Notes = PaymentMode.Notes;
                        
                        //for POM Collection
                        paymentModeInfoBo.POMCollection = new List<POMBo>();
                        foreach (var POM in PaymentMode.POMs)
                        {
                            POMBo POMBo = new POMBo();
                            POMBo.ID = POM.ID;

                            paymentModeInfoBo.POMCollection.Add(POMBo);
                        }
                        //

                        res.PaymentModeInfoCollection.Add(paymentModeInfoBo);

                    }
                    res.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
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
    }
}
