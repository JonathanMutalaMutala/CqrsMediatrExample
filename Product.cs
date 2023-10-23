namespace CqrsMediatrExample
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class  FakeDataStore
    {
        private static List<Product> _products; 


        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1,Name = "Produit 1"},
                new Product { Id = 2,Name = "Produit 2"},
                new Product { Id = 3,Name= "Produit 3"}
            };
        }

        /// <summary>
        ///  Permet d'ajouter un produit 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product)
        {
            _products.Add(product);
            return product; //await Task.FromResult(product);
        }

        /// <summary>
        /// Permet de recuperer tout les produits 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);
    }
}
