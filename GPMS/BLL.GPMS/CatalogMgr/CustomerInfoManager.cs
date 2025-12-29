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
    public class CustomerInfoManager : DbBase
    {
        /// <summary>
        /// Add new customer info.
        /// </summary>
        /// <param name="pCustomerInfoBo"></param>
        /// <returns></returns>
        public CatalogDto AddCustomer(CustomerInfoBo pCustomerInfoBo)
        {
            var resCatalogDto = new CatalogDto();
            try
            {
                CustomerInfo CustomerInfo = new CustomerInfo();
                
                //validate
                if (pCustomerInfoBo.CompanyID <= 0)
                {
                    throw new UserException("Please provide a valid companyID.");
                }

                if (pCustomerInfoBo.CustomerCode == null)
                {
                    throw new UserException("Please provide a valid CustomerCode.");
                }

                if (pCustomerInfoBo.CustomerName == null)
                {
                    throw new UserException("Please provide a valid CustomerName.");
                }

                if (pCustomerInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                //validate

                CustomerInfo.CustomerCode = pCustomerInfoBo.CustomerCode;
                CustomerInfo.CustomerName = pCustomerInfoBo.CustomerName;
                CustomerInfo.CompanyID = pCustomerInfoBo.CompanyID;
                CustomerInfo.ShortName = pCustomerInfoBo.ShortName;
                CustomerInfo.PreFix = pCustomerInfoBo.PreFix;
                CustomerInfo.Address = pCustomerInfoBo.Address;
                CustomerInfo.BillingAddress = pCustomerInfoBo.BillingAddress;
                CustomerInfo.PhoneNo = pCustomerInfoBo.PhoneNo;
                CustomerInfo.EMail = pCustomerInfoBo.EMail;
                CustomerInfo.FAX = pCustomerInfoBo.FAX;
                CustomerInfo.Country = pCustomerInfoBo.Country;
                CustomerInfo.State = pCustomerInfoBo.State;
                CustomerInfo.City = pCustomerInfoBo.City;
                CustomerInfo.Zipcode = pCustomerInfoBo.Zipcode;
                CustomerInfo.Description = pCustomerInfoBo.Description;
                CustomerInfo.IsActive = pCustomerInfoBo.IsActive;
                CustomerInfo.CreatedBy = pCustomerInfoBo.CreatedBy;
                CustomerInfo.CreatedAt = DateTime.Now;
                CustomerInfo.UpdatedCount = 0;

                EntitiesContext.CustomerInfoes.Add(CustomerInfo);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    resCatalogDto.DtoStatus = DtoStatus.Success;
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
                            resCatalogDto.DtoStatusNotes.Exception = "Customer code already exist.";
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
        /// Update existing customer info.
        /// </summary>
        /// <param name="pCustomerInfoBo"></param>
        /// <returns></returns>
        public CatalogDto UpdateCustomer(CustomerInfoBo pCustomerInfoBo)
        {
            var res = new CatalogDto();
            try
            {
                //validate
                if (pCustomerInfoBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid Customer ID.");
                }
                if (pCustomerInfoBo.CompanyID <= 0)
                {
                    throw new UserException("Please provide a valid companyID.");
                }

                if (pCustomerInfoBo.CustomerCode == null)
                {
                    throw new UserException("Please provide a valid CustomerCode.");
                }

                if (pCustomerInfoBo.CustomerName == null)
                {
                    throw new UserException("Please provide a valid CustomerName.");
                }

                if (pCustomerInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                //validate

                if (pCustomerInfoBo.ID <= 0)
                {
                    res.DtoStatus = DtoStatus.RecordNotAdded;
                    res.DtoStatusNotes.ExtraNotes.Add("Please provide a valid ID.");
                }

                var retCustomer = EntitiesContext.CustomerInfoes.Where(x => x.ID == pCustomerInfoBo.ID).FirstOrDefault();
                if (retCustomer != null)
                {
                    retCustomer.CustomerCode = pCustomerInfoBo.CustomerCode;
                    retCustomer.CustomerName = pCustomerInfoBo.CustomerName;
                    retCustomer.CompanyID = pCustomerInfoBo.CompanyID;
                    retCustomer.ShortName = pCustomerInfoBo.ShortName;
                    retCustomer.PreFix = pCustomerInfoBo.PreFix;
                    retCustomer.Address = pCustomerInfoBo.Address;
                    retCustomer.BillingAddress = pCustomerInfoBo.BillingAddress;
                    retCustomer.PhoneNo = pCustomerInfoBo.PhoneNo;
                    retCustomer.EMail = pCustomerInfoBo.EMail;
                    retCustomer.FAX = pCustomerInfoBo.FAX;
                    retCustomer.Country = pCustomerInfoBo.Country;
                    retCustomer.State = pCustomerInfoBo.State;
                    retCustomer.City = pCustomerInfoBo.City;
                    retCustomer.Zipcode = pCustomerInfoBo.Zipcode;
                    retCustomer.Description = pCustomerInfoBo.Description;
                    retCustomer.IsActive = pCustomerInfoBo.IsActive;
                    retCustomer.UpdatedBy = pCustomerInfoBo.UpdatedBy;
                    retCustomer.UpdatedAt = DateTime.Now;
                    retCustomer.UpdatedCount = retCustomer.UpdatedCount + 1;

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
        /// Get customer info. against given customer id.
        /// </summary>
        /// <param name="pCustomerId"></param>
        /// <returns></returns>
        public CatalogDto GetCustomerById(int pCustomerId)
        {
            var response = new CatalogDto();
            try
            {
                //validate
                if (pCustomerId > 0)
                {
                    throw new UserException("Please provide a valid Customer Id.");
                }
                //validate

                response.DtoStatus = DtoStatus.Failed;
                var cust = EntitiesContext.CustomerInfoes.Where(x => x.ID == pCustomerId).FirstOrDefault();
                if (cust != null)
                {
                    response.CustomerInfoBo = new CustomerInfoBo();
                    response.CustomerInfoBo.ID = cust.ID;
                    response.CustomerInfoBo.CustomerCode = cust.CustomerCode;
                    response.CustomerInfoBo.CustomerName = cust.CustomerName;
                    response.CustomerInfoBo.CompanyID = cust.CompanyID;
                    response.CustomerInfoBo.ShortName = cust.ShortName;
                    response.CustomerInfoBo.PreFix = cust.PreFix;
                    response.CustomerInfoBo.Address = cust.Address;
                    response.CustomerInfoBo.BillingAddress = cust.BillingAddress;
                    response.CustomerInfoBo.PhoneNo = cust.PhoneNo;
                    response.CustomerInfoBo.EMail = cust.EMail;
                    response.CustomerInfoBo.FAX = cust.FAX;
                    response.CustomerInfoBo.Country = cust.Country;
                    response.CustomerInfoBo.State = cust.State;
                    response.CustomerInfoBo.City = cust.City;
                    response.CustomerInfoBo.Zipcode = cust.Zipcode;
                    response.CustomerInfoBo.Description = cust.Description;
                    response.CustomerInfoBo.IsActive = cust.IsActive;
                    response.CustomerInfoBo.CreatedBy = cust.CreatedBy;
                    response.CustomerInfoBo.CreatedAt = cust.CreatedAt;
                    response.CustomerInfoBo.UpdatedBy = cust.UpdatedBy;
                    response.CustomerInfoBo.UpdatedAt = cust.UpdatedAt;
                    response.CustomerInfoBo.UpdatedCount = cust.UpdatedCount;
                    response.CustomerInfoBo.Notes = cust.Notes;

                    response.CompanyInfoBo = new CompanyInfoBo();
                    response.CompanyInfoBo.ID = cust.CompanyID;
                    response.CompanyInfoBo.CompanyName = cust.CompanyInfo.CompanyName;

                    response.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    response.DtoStatus = DtoStatus.NoDataFound;
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
        /// Get customer info. against given customer code.
        /// </summary>
        /// <param name="pCustomerCode"></param>
        /// <returns></returns>
        public CatalogDto GetCustomerByCode(string pCustomerCode)
        {
            var response = new CatalogDto();
            try
            {
                //validate
                if (pCustomerCode == null)
                {
                    throw new UserException("Please provide a valid CustomerCode.");
                }
                //validate


                response.DtoStatus = DtoStatus.Failed;
                var cust = EntitiesContext.CustomerInfoes.Where(x => x.CustomerCode.ToUpper().Trim() == pCustomerCode.ToUpper().Trim()).FirstOrDefault();
                if (cust != null)
                {
                    response.CustomerInfoBo = new CustomerInfoBo();
                    response.CustomerInfoBo.ID = cust.ID;
                    response.CustomerInfoBo.CustomerCode = cust.CustomerCode;
                    response.CustomerInfoBo.CustomerName = cust.CustomerName;
                    response.CustomerInfoBo.CompanyID = cust.CompanyID;
                    response.CustomerInfoBo.ShortName = cust.ShortName;
                    response.CustomerInfoBo.PreFix = cust.PreFix;
                    response.CustomerInfoBo.Address = cust.Address;
                    response.CustomerInfoBo.BillingAddress = cust.BillingAddress;
                    response.CustomerInfoBo.PhoneNo = cust.PhoneNo;
                    response.CustomerInfoBo.EMail = cust.EMail;
                    response.CustomerInfoBo.FAX = cust.FAX;
                    response.CustomerInfoBo.Country = cust.Country;
                    response.CustomerInfoBo.State = cust.State;
                    response.CustomerInfoBo.City = cust.City;
                    response.CustomerInfoBo.Zipcode = cust.Zipcode;
                    response.CustomerInfoBo.Description = cust.Description;
                    response.CustomerInfoBo.IsActive = cust.IsActive;
                    response.CustomerInfoBo.CreatedBy = cust.CreatedBy;
                    response.CustomerInfoBo.CreatedAt = cust.CreatedAt;
                    response.CustomerInfoBo.UpdatedBy = cust.UpdatedBy;
                    response.CustomerInfoBo.UpdatedAt = cust.UpdatedAt;
                    response.CustomerInfoBo.UpdatedCount = cust.UpdatedCount;
                    response.CustomerInfoBo.Notes = cust.Notes;

                    response.CompanyInfoBo = new CompanyInfoBo();
                    response.CompanyInfoBo.ID = cust.CompanyID;
                    response.CompanyInfoBo.CompanyName = cust.CompanyInfo.CompanyName;

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

        /// <summary>
        /// To Get all customer then pass parameter value as 'null'. 
        /// To Get all active customer then pass parameter value as 'true'. 
        /// To Get all In-active customer then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllCustomers(bool? pIsActive)
        {
            var response = new CatalogDto();
            try
            {
                response.DtoStatus = DtoStatus.Failed;
                List<CustomerInfo> result;
                if (pIsActive.HasValue) // for active or in-active
                    result = EntitiesContext.CustomerInfoes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    result = EntitiesContext.CustomerInfoes.ToList(); // all customer

                if (result != null && result.Count > 0)
                {
                    response.CustomerInfoCollection = new List<CustomerInfoBo>();
                    foreach (var cust in result)
                    {
                        CustomerInfoBo customerInfoBo = new CustomerInfoBo();
                        customerInfoBo.ID = cust.ID;
                        customerInfoBo.CustomerCode = cust.CustomerCode;
                        customerInfoBo.CustomerName = cust.CustomerName;
                        customerInfoBo.CompanyID = cust.CompanyID;
                        customerInfoBo.ShortName = cust.ShortName;
                        customerInfoBo.PreFix = cust.PreFix;
                        customerInfoBo.Address = cust.Address;
                        customerInfoBo.BillingAddress = cust.BillingAddress;
                        customerInfoBo.PhoneNo = cust.PhoneNo;
                        customerInfoBo.EMail = cust.EMail;
                        customerInfoBo.FAX = cust.FAX;
                        customerInfoBo.Country = cust.Country;
                        customerInfoBo.State = cust.State;
                        customerInfoBo.City = cust.City;
                        customerInfoBo.Zipcode = cust.Zipcode;
                        customerInfoBo.Description = cust.Description;
                        customerInfoBo.IsActive = cust.IsActive;
                        customerInfoBo.CreatedBy = cust.CreatedBy;
                        customerInfoBo.CreatedAt = cust.CreatedAt;
                        customerInfoBo.UpdatedBy = cust.UpdatedBy;
                        customerInfoBo.UpdatedAt = cust.UpdatedAt;
                        customerInfoBo.UpdatedCount = cust.UpdatedCount;
                        customerInfoBo.Notes = cust.Notes;

                        customerInfoBo.CompanyInfoBo = new CompanyInfoBo();
                        customerInfoBo.CompanyInfoBo.ID = cust.CompanyID;
                        customerInfoBo.CompanyInfoBo.CompanyName = cust.CompanyInfo.CompanyName;


                        response.CustomerInfoCollection.Add(customerInfoBo);

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

    }
}
