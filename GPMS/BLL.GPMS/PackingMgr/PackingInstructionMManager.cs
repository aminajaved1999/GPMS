using Entities.GPMS;
using MODEL.GPMS;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GPMS.PackingMgr
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

                PackingInstructionM.ID = packingInstructionMBo.ID;
                PackingInstructionM.CustomerID = packingInstructionMBo.CustomerID;
                PackingInstructionM.OrderID = packingInstructionMBo.OrderID;
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
                PackingInstructionM.CreatedAt = DateTime.Now;
                PackingInstructionM.UpdatedBy = packingInstructionMBo.UpdatedBy;
                PackingInstructionM.UpdatedAt = packingInstructionMBo.UpdatedAt;
                PackingInstructionM.UpdatedCount = packingInstructionMBo.UpdatedCount;
                PackingInstructionM.Notes = packingInstructionMBo.Notes;
                PackingInstructionM.UpdatedCount = 0;

                EntitiesContext.PackingInstructionMs.Add(PackingInstructionM);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    resPackingInstructionM.DtoStatus = DtoStatus.Success;
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
    }
}
