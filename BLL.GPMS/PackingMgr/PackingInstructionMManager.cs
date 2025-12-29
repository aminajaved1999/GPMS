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
    public class PackingInstructionMManager : DbBase
    {
        /// <summary>
        /// Add new Packing Instruction M.
        /// </summary>
        /// <param name="packingInstructionMBo"></param>
        /// <returns></returns>
        public PackingDto AddPackingInstructionM(PackingInstructionMBo packingInstructionMBo)
        {
            PackingDto resPackingInstructionM = new PackingDto();

            try
            {
                PackingInstructionM PackingInstructionM = new PackingInstructionM();

                // validate
                if (packingInstructionMBo.CreatedByID == null)
                {
                    throw new UserException("CreatedByID can't be null.");
                }
                // validate

                PackingInstructionM.ID = packingInstructionMBo.ID;
                PackingInstructionM.CustomerID = packingInstructionMBo.CustomerID;
                PackingInstructionM.POMID = packingInstructionMBo.POMID;
                PackingInstructionM.PONo = packingInstructionMBo.PONo;
                PackingInstructionM.Status = packingInstructionMBo.Status;
                PackingInstructionM.BoxBarcode = packingInstructionMBo.BoxBarcode;
                PackingInstructionM.CaseGrossWeight = packingInstructionMBo.CaseGrossWeight;
                PackingInstructionM.CaseCBM = packingInstructionMBo.CaseCBM;
                PackingInstructionM.ContainerNo = packingInstructionMBo.ContainerNo;
                PackingInstructionM.CartonSequence = packingInstructionMBo.CartonSequence;
                PackingInstructionM.MarkFor = packingInstructionMBo.MarkFor;
                PackingInstructionM.StoreNo = packingInstructionMBo.StoreNo;
                PackingInstructionM.DC = packingInstructionMBo.DC;
                PackingInstructionM.UsageIndicator = packingInstructionMBo.UsageIndicator;
                PackingInstructionM.UccPO = packingInstructionMBo.UccPO;
                PackingInstructionM.UccDept = packingInstructionMBo.UccDept;
                PackingInstructionM.UccStyle = packingInstructionMBo.UccStyle;
                PackingInstructionM.UccColor = packingInstructionMBo.UccColor;
                PackingInstructionM.UccSize = packingInstructionMBo.UccSize;
                PackingInstructionM.UccPartners = packingInstructionMBo.UccPartners;
                PackingInstructionM.UccType = packingInstructionMBo.UccType;
                PackingInstructionM.UccCoo = packingInstructionMBo.UccCoo;
                PackingInstructionM.Description = packingInstructionMBo.Description;
                PackingInstructionM.CreatedBy = packingInstructionMBo.CreatedBy;
                PackingInstructionM.CreatedByID = packingInstructionMBo.CreatedByID;
                PackingInstructionM.CreatedAt = DateTime.Now;
                PackingInstructionM.Notes = packingInstructionMBo.Notes;
                PackingInstructionM.UpdatedCount = 0;

                EntitiesContext.PackingInstructionMs.Add(PackingInstructionM);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, packingInstructionMBo.CreatedByID.Value);
                    resPackingInstructionM.DtoStatus = DtoStatus.Success;
                    resPackingInstructionM.PackingInstructionMBo = new PackingInstructionMBo();
                    resPackingInstructionM.PackingInstructionMBo.ID = PackingInstructionM.ID;
                }
                else
                {
                    resPackingInstructionM.DtoStatus = DtoStatus.RecordNotAdded;
                    resPackingInstructionM.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
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
                            resPackingInstructionM.DtoStatus = DtoStatus.Error;
                            resPackingInstructionM.DtoStatusNotes.Exception = "PackingInstructionM already exist.";
                            resPackingInstructionM.DtoStatusNotes.ExtraNotes.Add("Violation in unique constraint");
                        }
                    }
                    else
                    {
                        resPackingInstructionM.DtoStatus = DtoStatus.Error;
                        resPackingInstructionM.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    resPackingInstructionM.DtoStatus = DtoStatus.Error;
                    resPackingInstructionM.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                resPackingInstructionM.DtoStatus = DtoStatus.RecordNotAdded;
                resPackingInstructionM.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                resPackingInstructionM.DtoStatus = DtoStatus.Error;
                resPackingInstructionM.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return resPackingInstructionM;
        }

        public PackingDto GetBoxDataByBarcode(string pBoxBacode)
        {
            PackingDto response = new PackingDto();
            response.DtoStatus = DtoStatus.Failed;
            try
            {
                // validate
                if (pBoxBacode == null)
                {
                    throw new UserException("Please provide a valid BoxBarcode.");
                }
                // validate

                response.DtoStatus = DtoStatus.Failed;
                var PackingInstructionM = EntitiesContext.PackingInstructionMs.Where(x => x.BoxBarcode == pBoxBacode).FirstOrDefault();
                if (PackingInstructionM != null)
                {
                    response.PackingInstructionMBo = new PackingInstructionMBo();
                    response.PackingInstructionMBo.ID = PackingInstructionM.ID;
                    response.PackingInstructionMBo.CustomerID = PackingInstructionM.CustomerID;
                    response.PackingInstructionMBo.POMID = PackingInstructionM.POMID;
                    response.PackingInstructionMBo.PONo = PackingInstructionM.PONo;
                    response.PackingInstructionMBo.Status = PackingInstructionM.Status;
                    response.PackingInstructionMBo.BoxBarcode = PackingInstructionM.BoxBarcode;
                    response.PackingInstructionMBo.CaseGrossWeight = PackingInstructionM.CaseGrossWeight;
                    response.PackingInstructionMBo.CaseCBM = PackingInstructionM.CaseCBM;
                    response.PackingInstructionMBo.ContainerNo = PackingInstructionM.ContainerNo;
                    response.PackingInstructionMBo.CartonSequence = PackingInstructionM.CartonSequence;
                    response.PackingInstructionMBo.MarkFor = PackingInstructionM.MarkFor;
                    response.PackingInstructionMBo.StoreNo = PackingInstructionM.StoreNo;
                    response.PackingInstructionMBo.DC = PackingInstructionM.DC;
                    response.PackingInstructionMBo.UsageIndicator = PackingInstructionM.UsageIndicator;
                    response.PackingInstructionMBo.UccPO = PackingInstructionM.UccPO;
                    response.PackingInstructionMBo.UccDept = PackingInstructionM.UccDept;
                    response.PackingInstructionMBo.UccStyle = PackingInstructionM.UccStyle;
                    response.PackingInstructionMBo.UccColor = PackingInstructionM.UccColor;
                    response.PackingInstructionMBo.UccSize = PackingInstructionM.UccSize;
                    response.PackingInstructionMBo.UccPartners = PackingInstructionM.UccPartners;
                    response.PackingInstructionMBo.UccType = PackingInstructionM.UccType;
                    response.PackingInstructionMBo.UccCoo = PackingInstructionM.UccCoo;
                    response.PackingInstructionMBo.Description = PackingInstructionM.Description;

                    //CustomerInfoBo
                    if (PackingInstructionM.CustomerInfo != null)
                    {
                        response.PackingInstructionMBo.CustomerInfoBo = new CustomerInfoBo();
                        response.PackingInstructionMBo.CustomerInfoBo.ID = PackingInstructionM.CustomerInfo.ID;
                        response.PackingInstructionMBo.CustomerInfoBo.CustomerCode = PackingInstructionM.CustomerInfo.CustomerCode;
                        response.PackingInstructionMBo.CustomerInfoBo.CustomerName = PackingInstructionM.CustomerInfo.CustomerName;
                        response.PackingInstructionMBo.CustomerInfoBo.CompanyID = PackingInstructionM.CustomerInfo.CompanyID;
                        response.PackingInstructionMBo.CustomerInfoBo.ShortName = PackingInstructionM.CustomerInfo.ShortName;
                        response.PackingInstructionMBo.CustomerInfoBo.PreFix = PackingInstructionM.CustomerInfo.PreFix;
                        response.PackingInstructionMBo.CustomerInfoBo.Address = PackingInstructionM.CustomerInfo.Address;
                        response.PackingInstructionMBo.CustomerInfoBo.BillingAddress = PackingInstructionM.CustomerInfo.BillingAddress;
                        response.PackingInstructionMBo.CustomerInfoBo.PhoneNo = PackingInstructionM.CustomerInfo.PhoneNo;
                        response.PackingInstructionMBo.CustomerInfoBo.EMail = PackingInstructionM.CustomerInfo.EMail;
                        response.PackingInstructionMBo.CustomerInfoBo.FAX = PackingInstructionM.CustomerInfo.FAX;
                        response.PackingInstructionMBo.CustomerInfoBo.Country = PackingInstructionM.CustomerInfo.Country;
                        response.PackingInstructionMBo.CustomerInfoBo.State = PackingInstructionM.CustomerInfo.State;
                        response.PackingInstructionMBo.CustomerInfoBo.City = PackingInstructionM.CustomerInfo.City;
                        response.PackingInstructionMBo.CustomerInfoBo.Zipcode = PackingInstructionM.CustomerInfo.Zipcode;
                        response.PackingInstructionMBo.CustomerInfoBo.Description = PackingInstructionM.CustomerInfo.Description;
                        response.PackingInstructionMBo.CustomerInfoBo.IsActive = PackingInstructionM.CustomerInfo.IsActive;
                        response.PackingInstructionMBo.CustomerInfoBo.CreatedBy = PackingInstructionM.CustomerInfo.CreatedBy;
                        response.PackingInstructionMBo.CustomerInfoBo.CreatedAt = PackingInstructionM.CustomerInfo.CreatedAt;
                        response.PackingInstructionMBo.CustomerInfoBo.UpdatedBy = PackingInstructionM.CustomerInfo.UpdatedBy;
                        response.PackingInstructionMBo.CustomerInfoBo.UpdatedAt = PackingInstructionM.CustomerInfo.UpdatedAt;
                        response.PackingInstructionMBo.CustomerInfoBo.UpdatedCount = PackingInstructionM.CustomerInfo.UpdatedCount;
                        response.PackingInstructionMBo.CustomerInfoBo.Notes = PackingInstructionM.CustomerInfo.Notes;
                        response.PackingInstructionMBo.CustomerInfoBo.SupplierNo = PackingInstructionM.CustomerInfo.SupplierNo;
                    }

                    //PackingInstructionDList
                    response.PackingInstructionMBo.PackingInstructionDList = new List<PackingInstructionDBo>();

                    foreach (var PackingInstructionD in PackingInstructionM.PackingInstructionDs)
                    {
                        var PackingInstructionDBo = new PackingInstructionDBo();
                        PackingInstructionDBo.ID = PackingInstructionD.ID;
                        PackingInstructionDBo.PackingInstructionMID = PackingInstructionD.PackingInstructionMID;
                        PackingInstructionDBo.ItemNo = PackingInstructionD.ItemNo;
                        PackingInstructionDBo.UPC = PackingInstructionD.UPC;
                        PackingInstructionDBo.UOMID = PackingInstructionD.UOMID;
                        PackingInstructionDBo.ColorID = PackingInstructionD.ColorID;
                        PackingInstructionDBo.StyleID = PackingInstructionD.StyleID;
                        PackingInstructionDBo.SizeID = PackingInstructionD.SizeID;
                        PackingInstructionDBo.ItemQtyPerCase = PackingInstructionD.ItemQtyPerCase;
                        PackingInstructionDBo.SequenceNo = PackingInstructionD.SequenceNo;
                        PackingInstructionDBo.StoreNo = PackingInstructionD.StoreNo;
                        PackingInstructionDBo.DC = PackingInstructionD.DC;
                        PackingInstructionDBo.ScanDate = PackingInstructionD.ScanDate;
                        PackingInstructionDBo.Description = PackingInstructionD.Description;

                        //color
                        if (PackingInstructionD.ColorInfo != null)
                        {
                            PackingInstructionDBo.ColorInfoBo = new ColorInfoBo();
                            PackingInstructionDBo.ColorInfoBo.ID = PackingInstructionD.ColorInfo.ID;
                            PackingInstructionDBo.ColorInfoBo.ColorCode = PackingInstructionD.ColorInfo.ColorCode;
                            PackingInstructionDBo.ColorInfoBo.ColorName = PackingInstructionD.ColorInfo.ColorName;
                            PackingInstructionDBo.ColorInfoBo.CustomerID = PackingInstructionD.ColorInfo.CustomerID;
                            PackingInstructionDBo.ColorInfoBo.Description = PackingInstructionD.ColorInfo.Description;
                            PackingInstructionDBo.ColorInfoBo.IsActive = PackingInstructionD.ColorInfo.IsActive;
                        }

                        //style
                        if (PackingInstructionD.StyleInfo != null)
                        {
                            PackingInstructionDBo.StyleInfoBo = new StyleInfoBo();
                            PackingInstructionDBo.StyleInfoBo.ID = PackingInstructionD.StyleInfo.ID;
                            PackingInstructionDBo.StyleInfoBo.StyleCode = PackingInstructionD.StyleInfo.StyleCode;
                            PackingInstructionDBo.StyleInfoBo.StyleName = PackingInstructionD.StyleInfo.StyleName;
                            PackingInstructionDBo.StyleInfoBo.CustomerID = PackingInstructionD.StyleInfo.CustomerID;
                            PackingInstructionDBo.StyleInfoBo.Description = PackingInstructionD.StyleInfo.Description;
                            PackingInstructionDBo.StyleInfoBo.IsActive = PackingInstructionD.StyleInfo.IsActive;
                        }

                        //size
                        if (PackingInstructionD.SizeInfo != null)
                        {
                            PackingInstructionDBo.SizeInfoBo = new SizeInfoBo();
                            PackingInstructionDBo.SizeInfoBo.ID = PackingInstructionD.SizeInfo.ID;
                            PackingInstructionDBo.SizeInfoBo.SizeCode = PackingInstructionD.SizeInfo.SizeCode;
                            PackingInstructionDBo.SizeInfoBo.SizeName = PackingInstructionD.SizeInfo.SizeName;
                            PackingInstructionDBo.SizeInfoBo.Description = PackingInstructionD.SizeInfo.Description;
                            PackingInstructionDBo.SizeInfoBo.IsActive = PackingInstructionD.SizeInfo.IsActive;
                        }

                        response.PackingInstructionMBo.PackingInstructionDList.Add(PackingInstructionDBo);
                    }

                    response.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    response.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                response.DtoStatus = DtoStatus.NoDataFound;
                response.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                response.DtoStatus = DtoStatus.Error;
                response.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return response;
        }


        public PackingDto SaveBoxPacking(int pPackingInstructionMID, int pUpdatedByID, string pUpdatedBy)
        {
            PackingDto response = new PackingDto();
            response.DtoStatus = DtoStatus.Failed;
            var dbContext = new GPMSEntities();
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    // validate
                    if (pPackingInstructionMID < 0)
                    {
                        throw new UserException("Please provide a valid PackingInstructionM ID.");
                    }
                    if (pUpdatedByID < 0)
                    {
                        throw new UserException("Please provide a valid  value for UpdatedByID.");
                    }

                    if (pUpdatedBy == null)
                    {
                        throw new UserException("Please provide a valid value for UpdatedBy.");
                    }
                    // validate

                    // Update PackingInstructionM
                    var packingInstructionM = EntitiesContext.PackingInstructionMs.Where(x => x.ID == pPackingInstructionMID).FirstOrDefault();
                    if (packingInstructionM != null)
                    {
                        packingInstructionM.Status = "P";
                        packingInstructionM.UpdatedByID = pUpdatedByID;
                        packingInstructionM.UpdatedBy = pUpdatedBy;
                        packingInstructionM.UpdatedAt = DateTime.Now;

                        // Update PackingInstructionD
                        var packingInstructionD = EntitiesContext.PackingInstructionDs.Where(x => x.PackingInstructionMID == pPackingInstructionMID).FirstOrDefault();
                        if (packingInstructionD != null)
                        {
                            packingInstructionD.ScanDate = DateTime.Now;
                            packingInstructionD.UpdatedByID = pUpdatedByID;
                            packingInstructionD.UpdatedBy = pUpdatedBy;
                            packingInstructionD.UpdatedAt = DateTime.Now;

                            var res = EntitiesContext.SaveChanges();
                            if (res > 0)
                            {
                                new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pUpdatedByID);
                                response.DtoStatus = DtoStatus.Success;
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                                response.DtoStatus = DtoStatus.RecordNotUpdatedWithoutChanges;
                                response.DtoStatusNotes.ExtraNotes.Add("No changes were made to the record.");
                            }
                        }
                        else
                        {
                            response.DtoStatus = DtoStatus.NoDataFound;
                            response.DtoStatusNotes.ExtraNotes.Add("packingInstructionD with the given ID not found.");
                        }
                        //
                    }
                    else
                    {
                        response.DtoStatus = DtoStatus.NoDataFound;
                        response.DtoStatusNotes.ExtraNotes.Add("packingInstructionM with the given ID not found.");
                    }
                    //

                }
                catch (UserException ux)
                {
                    response.DtoStatus = DtoStatus.Error;
                    response.DtoStatusNotes.Exception = ux.Message.ToString();
                    transaction.Rollback();
                }
                catch (Exception e)
                {
                    response.DtoStatus = DtoStatus.Error;
                    response.DtoStatusNotes.Exception = e.Message.ToString();
                    transaction.Rollback();
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }
                }
                return response;
            }
        }

    }
}
