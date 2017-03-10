namespace Shop.Authentication {

    internal interface ICheckUser {

        bool login(string usr, string pwd);
    }
}