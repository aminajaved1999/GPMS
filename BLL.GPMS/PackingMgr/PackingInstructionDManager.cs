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
    public class PackingInstructionDManager : DbBase
    {
        public PackingDto AddPackingInstructionD(PackingInstructionDBo packingInstructionDBo)
        {
            PackingDto resPackingInstructionD = new PackingDto();

            try
            {
                PackingInstructionD PackingInstructionD = new PackingInstructionD();

                // validate
                if (packingInstructionDBo.PackingInstructionMID <= 0)
                {
                    throw new UserException("Please provide a valid PackingInstructionMID.");
                }
                if (packingInstructionDBo.CreatedByID == null)
                {
                    throw new UserException("CreatedByID can't be null.");
                }
                // validate

                PackingInstructionD.ID = packingInstructionDBo.ID;
                PackingInstructionD.PackingInstructionMID = packingInstructionDBo.PackingInstructionMID;
                PackingInstructionD.ItemNo = packingInstructionDBo.ItemNo;
                PackingInstructionD.UPC = packingInstructionDBo.UPC;
                PackingInstructionD.UOMID = packingInstructionDBo.UOMID;
                PackingInstructionD.ItemQtyPerCase = packingInstructionDBo.ItemQtyPerCase;
                PackingInstructionD.SequenceNo = packingInstructionDBo.SequenceNo;
                PackingInstructionD.StoreNo = packingInstructionDBo.StoreNo;
                PackingInstructionD.DC = packingInstructionDBo.DC;
                PackingInstructionD.ScanDate = packingInstructionDBo.ScanDate;
                PackingInstructionD.Description = packingInstructionDBo.Description;
                PackingInstructionD.CreatedBy = packingInstructionDBo.CreatedBy;
                PackingInstructionD.CreatedByID = packingInstructionDBo.CreatedByID;
                PackingInstructionD.CreatedAt = DateTime.Now;
                PackingInstructionD.Notes = packingInstructionDBo.Notes;
                PackingInstructionD.UpdatedCount = 0;

                EntitiesContext.PackingInstructionDs.Add(PackingInstructionD);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, packingInstructionDBo.CreatedByID.Value);
                    resPackingInstructionD.DtoStatus = DtoStatus.Success;
                    resPackingInstructionD.PackingInstructionDBo = new PackingInstructionDBo();
                    resPackingInstructionD.PackingInstructionDBo.ID = PackingInstructionD.ID;
                }
                else
                {
                    resPackingInstructionD.DtoStatus = DtoStatus.RecordNotAdded;
                    resPackingInstructionD.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
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
                            resPackingInstructionD.DtoStatus = DtoStatus.Error;
                            resPackingInstructionD.DtoStatusNotes.Exception = "PackingInstructionD already exist.";
                            resPackingInstructionD.DtoStatusNotes.ExtraNotes.Add("Violation in unique constraint");
                        }
                    }
                    else
                    {
                        resPackingInstructionD.DtoStatus = DtoStatus.Error;
                        resPackingInstructionD.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    resPackingInstructionD.DtoStatus = DtoStatus.Error;
                    resPackingInstructionD.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                resPackingInstructionD.DtoStatus = DtoStatus.RecordNotAdded;
                resPackingInstructionD.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                resPackingInstructionD.DtoStatus = DtoStatus.Error;
                resPackingInstructionD.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return resPackingInstructionD;
        }
    }
}
