namespace Shop.Models.DTO {

    public static class Extension {

        public static bool Check(this string s) {
            return s.Length > 10 ? true : false;
        }
    }
}