using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LearnEngineeringPaymentPortal.Models;

namespace LearnEngineeringPaymentPortal.DAL
{
    public class MathsHelper : Interface1 
    {
        public MathsHelper() { }
        public int Add(int a, int b)
        {
            int x = a + b;
            return x;

        }
        public string ApplyDiscountCoupenForUser(string discountCode)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

                List<CoupenAvailability> checkCoupens = new List<CoupenAvailability>();
                try
                {
                    checkCoupens = (from pdm in contextsdce.promo_discount_master
                                    where pdm.discount_code == discountCode && pdm.discount_expiryon >= DateTime.Today
                                    && pdm.active_status == 1
                                    select new CoupenAvailability
                                    {
                                        DiscountPrice = pdm.discount_price,
                                        ExtendedDays = pdm.discount_extend_days
                                    }).ToList();
                    if (checkCoupens.Any())
                    {
                        return jsSerializer.Serialize(checkCoupens);
                    }
                    else
                    {
                        return "Discount Coupen Not Avaliable";
                    }

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }

    }
}