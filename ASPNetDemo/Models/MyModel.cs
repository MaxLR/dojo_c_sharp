public class MyModel {
    public string FavoritePokemon { get; set; }

    public List<int> NumbersILike { get; set; }

    public MyModel(string favoritePokemon, List<int> numbers) {
        FavoritePokemon = favoritePokemon;
        NumbersILike = numbers;
    }
}