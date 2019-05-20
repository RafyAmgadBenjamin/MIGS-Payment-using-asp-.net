namespace MIGS.Helpers
{
    public static class PaymentCodesHelper
    {
        public static string Version
        {
            get
            {
                return "MasterCard 2.0";
            }
        }

        public static string GetTxnResponseCodeDescription(string TxnResponseCode)
        {
            string result = "";

            if (string.IsNullOrWhiteSpace(TxnResponseCode) || TxnResponseCode.Equals("null"))
            {
                result = "null response";
            }
            else
            {
                switch (TxnResponseCode)
                {
                    case "0": result = "Transaction Successful"; break;
                    case "1": result = "Transaction Declined"; break;
                    case "2": result = "Bank Declined Transaction"; break;
                    case "3": result = "No Reply from Bank"; break;
                    case "4": result = "Expired Card"; break;
                    case "5": result = "Insufficient Funds"; break;
                    case "6": result = "Error Communicating with Bank"; break;
                    case "7": result = "Payment Server detected an error"; break;
                    case "8": result = "Transaction Type Not Supported"; break;
                    case "9": result = "Bank declined transaction (Do not contact Bank)"; break;
                    case "A": result = "Transaction Aborted"; break;
                    case "B": result = "Transaction Declined - Contact the Bank"; break;
                    case "C": result = "Transaction Cancelled"; break;
                    case "D": result = "Deferred transaction has been received and is awaiting processing"; break;
                    case "E": result = "Transaction Declined - Refer to card issuer"; break;
                    case "F": result = "3-D Secure Authentication failed"; break;
                    case "I": result = "Card Security Code verification failed"; break;
                    case "L": result = "Shopping Transaction Locked (Please try the transaction again later)"; break;
                    case "M": result = "Transaction Submitted (No response from acquirer)"; break;
                    case "N": result = "Cardholder is not enrolled in Authentication scheme"; break;
                    case "P": result = "Transaction has been received by the Payment Adaptor and is being processed"; break;
                    case "R": result = "Transaction was not processed - Reached limit of retry attempts allowed"; break;
                    case "S": result = "Duplicate SessionID"; break;
                    case "T": result = "Address Verification Failed"; break;
                    case "U": result = "Card Security Code Failed"; break;
                    case "V": result = "Address Verification and Card Security Code Failed"; break;
                    case "?": result = "Transaction status is unknown"; break;
                    default: result = "Unable to be determined"; break;
                }
            }
            return result;
        }

        /// <summary>
        /// This function uses the CSC Result Code retrieved from the Digital
        /// Receipt and returns an appropriate description for this code.
        /// <param vCSCResultCode string containing the CSC Result Code
        /// </summary>
        /// <param name="CSCResultCode">string containing the CSC Result Code.</param>
        /// <returns>string containing the appropriate description.</returns>
        public static string GetCSCDescription(string CSCResultCode)
        {
            string result = "";
            if (!string.IsNullOrWhiteSpace(CSCResultCode))
            {
                if (CSCResultCode.Equals("Unsupported", System.StringComparison.OrdinalIgnoreCase))
                {
                    result = "CSC not supported or there was no CSC data provided";
                }
                else
                {
                    switch (CSCResultCode)
                    {
                        case "M": result = "Exact code match"; break;
                        case "S": result = "Merchant has indicated that CSC is not present on the card (MOTO situation)"; break;
                        case "P": result = "Code not processed"; break;
                        case "U": result = "Card issuer is not registered and/or certified"; break;
                        case "N": result = "Code invalid or not matched"; break;
                        default: result = "Unable to be determined"; break;
                    }
                }
            }
            else
            {
                result = "null response";
            }
            return result;
        }

        /// <summary>
        /// This function uses the AVS Result Code retrieved from the Digital
        /// Receipt and returns an appropriate description for this code.
        /// </summary>
        /// <param name="AVSResultCode">AVSResultCode string containing the CSC Result Code</param>
        /// <returns>description string containing the appropriate description.</returns>
        public static string GetAVSDescription(string AVSResultCode)
        {
            string result = "";
            if (!string.IsNullOrWhiteSpace(AVSResultCode))
            {
                if (AVSResultCode.Equals("Unsupported", System.StringComparison.OrdinalIgnoreCase))
                {
                    result = "AVS not supported or there was no AVS data provided";
                }
                else
                {
                    switch (AVSResultCode)
                    {
                        case "X": result = "Exact match - address and 9 digit ZIP/postal code"; break;
                        case "Y": result = "Exact match - address and 5 digit ZIP/postal code"; break;
                        case "S": result = "Service not supported or address not verified (international transaction)"; break;
                        case "G": result = "Issuer does not participate in AVS (international transaction)"; break;
                        case "C": result = "Street Address and Postal Code not verified for International Transaction due to incompatible formats."; break;
                        case "I": result = "Visa Only. Address information not verified for international transaction."; break;
                        case "A": result = "Address match only"; break;
                        case "W": result = "9 digit ZIP/postal code matched, Address not Matched"; break;
                        case "Z": result = "5 digit ZIP/postal code matched, Address not Matched"; break;
                        case "R": result = "Issuer system is unavailable"; break;
                        case "U": result = "Address unavailable or not verified"; break;
                        case "E": result = "Address and ZIP/postal code not provided"; break;
                        case "B": result = "Street Address match for international transaction. Postal Code not verified due to incompatible formats."; break;
                        case "N": result = "Address and ZIP/postal code not matched"; break;
                        case "0": result = "AVS not requested"; break;
                        case "D": result = "Street Address and postal code match for international transaction."; break;
                        case "M": result = "Street Address and postal code match for international transaction."; break;
                        case "P": result = "Postal Codes match for international transaction but street address not verified due to incompatible formats."; break;
                        case "K": result = "Card holder name only matches."; break;
                        case "F": result = "Street address and postal code match. Applies to U.K. only."; break;
                        default: result = "Unable to be determined"; break;
                    }
                }
            }
            else
            {
                result = "null response";
            }
            return result;
        }

        /// <summary>
        /// This function uses the Verification Status Code returned by in
        /// the Authentication data of a transaction or Authentication request.
        /// </summary>
        /// <param name="VerStatus">string containing the VerStatus Result Code</param>
        /// <returns>description string containing the appropriate description</returns>
        public static string GetVerStatusDescription(string VerStatus)
        {
            string result = "";
            if (!string.IsNullOrWhiteSpace(VerStatus))
            {
                if (VerStatus.Equals("unsupported", System.StringComparison.OrdinalIgnoreCase))
                {
                    result = "Authentication not supported or there was no Authentication data provided";
                }
                else
                {
                    switch (VerStatus)
                    {
                        case "Y": result = "Cardholder was successfully authenticated."; break;
                        case "E": result = "Cardholder is not enrolled."; break;
                        case "N": result = "Cardholder was not verified."; break;
                        case "U": result = "Issuer system error."; break;
                        case "F": result = "Data supplied in the request was invalid."; break;
                        case "A": result = "Authentication of the merchant credentials to the Directory Server failed."; break;
                        case "D": result = "Error communicating with the Directory Server."; break;
                        case "C": result = "Card type is not supported for authentication."; break;
                        case "S": result = "Response received from the Issuer was invalid."; break;
                        case "P": result = "Error parsing input from Issuer."; break;
                        case "I": result = "Internal Payment Server system error."; break;
                        default: result = "Unable to be determined"; break;
                    }
                }
            }
            else
            {
                result = "null response";
            }
            return result;
        }
    }
}
