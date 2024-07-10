using System;
using System.Collections.Generic;
using Stripe;

namespace Project.Function
{

    public class StripeMode
    {
        public string API_KEY = "";
        public string STANDARD_PRICE_ID = "";

        public StripeMode(string _mode)
        {
            string TEST_API_KEY = "sk_test_51PTJQKIk0AVC4o259oe9J88pSCnZwAexxmvk9bnLdxNMxKiAIwuWX9Ow4aXKwDcMTMFHQXkR8wDXVML6LzzuQ797009z1JA0B1";
            string TEST_PRICE_ID = "price_1PVJRTIk0AVC4o25lBDr9b9l";

            string LIVE_API_KEY = "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";
            string LIVE_PRICE_ID = "price_1PVJTDIk0AVC4o253h84P2T0";


            if (_mode == "TEST")
            {
                API_KEY = LIVE_API_KEY;
                STANDARD_PRICE_ID = LIVE_PRICE_ID;

            }else{
                API_KEY = TEST_API_KEY;
                STANDARD_PRICE_ID = TEST_PRICE_ID;
            }
        }
    }

    public static class StripeService
    {
        private static readonly string _CURRENT_MODE = "LIVE";


        // WebhookSigningKey
        public static readonly string LiveWebhookSigningKey = "whsec_k5wEPrdYfimgZHNnYv9rL8NPN93wlH4n";
        public static readonly string TestWebhookSigningKey = "whsec_UisK0W2T1pvEAI9qoni6BsFClADl1Isa";

        // private static readonly string StandardPriceId = "price_1PUjl7Ik0AVC4o25QPjTEhuv";

        public static string CreateBACSSubscription(Customer _customer)
        {
            StripeMode mode = new StripeMode(_CURRENT_MODE);

            // Create Customer
            Stripe.Customer customer = CreateUser(_customer);

            // Create Payment Method
            PaymentMethod paymentMethod = CreateBACSPaymentMethod(_customer);

            // Attach the Payment Method to the Customer
            SetDefaultPaymentMethod(customer, paymentMethod);

            var subscriptionOptions = new SubscriptionCreateOptions
            {
                Customer = customer.Id,
                Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions
                    {
                        Price = mode.STANDARD_PRICE_ID,  // Replace with your price ID from the Stripe Dashboard
                    },
                },
                DefaultPaymentMethod = paymentMethod.Id,
                PaymentBehavior = "default_incomplete",
                Expand = new List<string> { "latest_invoice.payment_intent" },
            };

            var subscriptionService = new SubscriptionService();
            Subscription subscription = subscriptionService.Create(subscriptionOptions);

            return customer.Id;
        }
    
        public static void DeleteCustomer(string customerId)
        {
            StripeMode mode = new StripeMode(_CURRENT_MODE);

            StripeConfiguration.ApiKey = mode.API_KEY;
            var customerService = new CustomerService();

            try
            {
                var deletedCustomer = customerService.Delete(customerId);
            }
            catch (StripeException e)
            {
            }
        }
   
        private static Stripe.Customer CreateUser(Customer _customer)
        {
            StripeMode mode = new StripeMode(_CURRENT_MODE);
            StripeConfiguration.ApiKey = mode.API_KEY;

            var options = new CustomerCreateOptions
            {
                Email = _customer.Email,
                Name = _customer.Name,
            };

            var service = new CustomerService();
            Stripe.Customer customer = service.Create(options);

            return customer;
        }

        private static PaymentMethod CreateBACSPaymentMethod(Customer _customer)
        {
            var paymentMethodOptions = new PaymentMethodCreateOptions
            {
                Type = "bacs_debit",
                BacsDebit = new PaymentMethodBacsDebitOptions
                {
                    SortCode = _customer.SortCode,
                    AccountNumber = _customer.AccountNumber,
                },
                BillingDetails = new PaymentMethodBillingDetailsOptions
                {
                    Name = _customer.Name,
                    Email = _customer.Email,
                    Address = new AddressOptions
                    {
                        Line1 = _customer.Address_Line1,
                        City = _customer.Address_City,
                        PostalCode = _customer.Address_PostalCode,
                        Country = "GB",
                    }
                },
            };

            var paymentMethodService = new PaymentMethodService();
            PaymentMethod paymentMethod = paymentMethodService.Create(paymentMethodOptions);

            return paymentMethod;
        }

        private static void SetDefaultPaymentMethod(Stripe.Customer customer, PaymentMethod paymentMethod)
        {
            var service = new CustomerService();
            var paymentMethodService = new PaymentMethodService();

            var attachOptions = new PaymentMethodAttachOptions
            {
                Customer = customer.Id,
            };
            paymentMethodService.Attach(paymentMethod.Id, attachOptions);

            // Set the Payment Method as the default for the Customer
            var customerUpdateOptions = new CustomerUpdateOptions
            {
                InvoiceSettings = new CustomerInvoiceSettingsOptions
                {
                    DefaultPaymentMethod = paymentMethod.Id,
                },
            };
            service.Update(customer.Id, customerUpdateOptions);
        }

        public static void SetAutomaticCollectionForInvoice(string invoiceID)
        {
            StripeMode mode = new StripeMode(_CURRENT_MODE);

            StripeConfiguration.ApiKey = mode.API_KEY;

            var options = new InvoiceUpdateOptions { AutoAdvance = true };
            var service = new InvoiceService();
            service.Update(invoiceID, options);
        }
    }
}