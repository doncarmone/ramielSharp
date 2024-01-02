namespace ramielsharp.Auth;


public static partial class Allow
{
    public const string Article_Delete = "100";
    public const string Article_Update = "101";
    public const string Author_Update = "102";

    public const string Genres_Read = "100";
    public const string Novels_Read = "200";

    // public static partial void Groups()
    // {
    //     AddToWriter(Genres_Read);
    //     AddToWriter(Novels_Read);
    //     
    //     AddToAdmin(Novels_Read);
    //     // AddToAuthor(Author_Update);
    //     //
    //     // AddToAdmin(Article_Delete);
    //     // AddToAdmin(Article_Update);
    //     // AddToAdmin(Author_Update);
    // }
}