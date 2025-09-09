namespace SpotMarket.Shared.Models.Presentation
{
    public interface IPublicMsg
    {
        public const string RECEIVE_MSG = "PublicReceiveMsg";
        public const string RECEIVE_DEL_MSG = "PublicReceiveDeleteMsg";
        public const string TIME_RECEIVE_MSG = "TimeReceiveMsg";
        public const string MarketStepRECEIVEMSG = "MarketStepReceiveMsg";

        public const string TradeOrder_RECEIVE_MSG = "TradeOrderReceiveMsg";
        public const string TradeOrder_DEL_RECEIVE_MSG = "TradeOrderDelReceiveMsg";

        public const string SYSTEM_MSG = "PublicSystemMsg";
        public const string USERS = "UserList";
        /// <summary>
        /// Event name when a message is received
        /// </summary>
        public const string RECEIVE = "ReceiveMessage";
        /// <summary>
        /// Name of the Hub method to send a message
        /// </summary>
        public const string SEND = "SendMessage";
    }
}
