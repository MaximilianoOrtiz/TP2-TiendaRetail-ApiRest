using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class DbTiendaRetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Parametry",
                columns: table => new
                {
                    ParametriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametry", x => x.ParametriaId);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_Category",
                        column: x => x.Category,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Product_Product",
                        column: x => x.Product,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sale_Sale",
                        column: x => x.Sale,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electrodomésticos" },
                    { 2, "Tecnologia y Electrónica" },
                    { 3, "Moda y Accesorios" },
                    { 4, "Hogar y Decoración" },
                    { 5, "Salud y Belleza" },
                    { 6, "Deportes y Ocio" },
                    { 7, "Juguetes y Juegos" },
                    { 8, "Alimentos y Bebidas" },
                    { 9, "Libros y Material Eductivo" },
                    { 10, "Jardineria y Bricola" }
                });

            migrationBuilder.InsertData(
                table: "Parametry",
                columns: new[] { "ParametriaId", "Codigo", "Value" },
                values: new object[] { 1, "taxe_iva", 21m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Category", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("00aac302-8293-4f56-bf55-0fac8f35c895"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("03b45ee4-de23-468f-993b-9de77bef07e7"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("06bcb0ee-699f-4f70-ac96-b28ed65c3da5"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("0c90ad99-2961-4f76-8fff-a6583567d105"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("13441901-a744-4063-8deb-e805a27c3bc4"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("143f773b-827d-4e36-8cf3-7aad40400d48"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("16711208-6699-4ce9-b7f4-2ddea76ed1ff"), 1, "Lavadora de carga frontal con capacidad de lavado de 10.5 kg. Tecnología EcoBubble que activa el detergente con aire y agua antes de que comience el ciclo de lavado, garantizando una limpieza profunda incluso en agua fría. Eficiencia energética A+++, múltiples programas de lavado, pantalla LED táctil, y sistema de auto-limpieza.", 4, "https://http2.mlstatic.com/D_NQ_NP_910743-MLA73490348656_122023-O.webp", "Lavarropa Samsung Ww10t504daw 10kg Blanco Con Ia Inverter", 2000999m },
                    { new Guid("17f44f3a-48d3-432a-b5f1-53f13bcdfaae"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("187f3a29-cc08-4770-8a39-48b22ad9ae99"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("1ac16293-3bb1-4a29-9929-ff13879845ae"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("2143d2c2-fdcb-4b15-bfee-94a22fd4865d"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("2373544b-cacb-4aaf-9ba9-3ef99361a115"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m },
                    { new Guid("269b9b41-d76c-49b9-83ca-3e9eedca92a1"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("2913f385-99da-4090-b136-5273d0f8bdce"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("2ca4cfc5-85c7-41fd-92cf-4d5f8238df4c"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("2f30a9cc-d14b-4f61-a086-7ad29ae226a8"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("33857d2f-4ce6-4cdf-931d-3a9f7d1a935c"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("33f3dedb-83d1-4332-b8e5-30c184c6294a"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("3424bd93-2864-4fce-9942-db1bd6ed263a"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://http2.mlstatic.com/D_NQ_NP_871625-MLA75823629201_042024-O.webp", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("34b33f43-ed50-4f18-8eba-9a52adc6baf3"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("38663bf0-3bca-401b-8d59-1ede42bc92ff"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("3887dd40-7924-49de-8cfe-9caf6add157a"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("3a04d161-a786-4d9f-bff0-bfba70dccc97"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("3d74c30a-bf4b-4123-b0f5-f683b84b9453"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("49348ac7-f690-464b-879f-e44d427c2e3c"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("4b8c15a5-bc43-4c36-81a7-d954904fff18"), 1, "Aire acondicionado con capacidad de frío de 3000 frigorías y capacidad de calor de 3000 watts. Tecnología Inverter, eficiencia energética A, función de deshumidificación, timer programable, control remoto y modo Sleep.", 5, "https://www.fravega.com/p/aire-acondicionado-split-frio-calor-surrey-3000f-3490w-553bfq1201e--20459/", "Aire Acondicionado Split Surrey Inverter Frio/Calor 3000 F", 1489999m },
                    { new Guid("4c5def02-86f0-4d8a-a4bf-1fe0ae39e6a9"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("4d91e358-a233-469d-8e20-ce47c29aaa12"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("4dff321a-1973-479d-bfa2-b86d37ea8ada"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("4f0e7bc8-cb24-4097-897c-f39c6a3412e7"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("51d3ea1c-d8a1-40c1-ae2b-a3350205207d"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("522e01c1-b864-4baa-8734-2aec56dcdb8b"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("52437375-71c4-47eb-a729-435a9d4b9792"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m },
                    { new Guid("52ba4980-3c85-45a2-976a-877e711c8cd3"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("53bbbbc0-7d93-4003-a077-156002bd0776"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("53f37b64-bc4b-4305-86ec-531b91db8310"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("55f49b3c-849b-4f9e-b7b5-733f9bee478a"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("5698dfdd-ac06-4a2d-9669-f5b3d25b5f47"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://http2.mlstatic.com/D_NQ_NP_871625-MLA75823629201_042024-O.webpg", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("570b28ee-e8e3-4cf3-87b0-456a9f60b398"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m },
                    { new Guid("57f5a861-3721-4bc0-8572-6eadaf73db34"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("581936bf-1439-4e1a-b549-d3f1ebd21e7a"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("5836e9ed-be73-4c5a-98c6-5fa7be76f895"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("59da04e5-044c-42ee-ae1a-3ce2455ab823"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("5c79275b-c202-486c-bf26-72a6f84319d8"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m },
                    { new Guid("5e911bec-80f6-494a-adee-095ecd8ac525"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("68979080-e35c-446e-8281-2644346b5f0b"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("6908fe49-3e6f-463a-84f1-6c171e456d3e"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("6ffb2fde-2b92-41e8-9292-1a2cc413eecf"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("7848384f-9d3a-4d44-b890-887c96d43e0f"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://http2.mlstatic.com/D_NQ_NP_871625-MLA75823629201_042024-O.webp", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("79b0096b-e936-4e0b-96d9-b67c72ae9efa"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("7a08b9d8-105c-41e7-ba93-5616146c7b96"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("7a2d2d12-9de9-4026-956e-db73fddc1f5e"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("7be312d1-513f-461d-b88e-e62aff70d2a2"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m },
                    { new Guid("7eb0d139-f1a9-4aa6-9a84-ee6792da1dbf"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("81662cf8-6801-44b7-9884-b041e0fbc9bc"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("8bea91bf-1118-49b7-a6e1-45560627e1f5"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("8e688d40-9cca-47df-8ba7-44d81c128c39"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("90b8dfa7-b298-4a60-aca2-43bb748750a7"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("91a448bc-9960-41e0-a997-a9f458100dfd"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("91a64e43-1777-42be-9c41-5778df6f2093"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("936fb017-90f4-49ef-8e46-6748af45ece2"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m },
                    { new Guid("94520a5d-2aba-4e23-97fc-a123568fe52e"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("9469da21-bd4e-43ac-8a72-604b190548a1"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("95d982ea-6e32-4696-89f1-cb5e5c336a8c"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("95ef3b5d-fc06-4bcc-94b6-ea1746c3d2b7"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("97f7e14c-95d8-4cc0-8260-8f6260919865"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("98195b2c-9938-483d-9646-7a657d905eba"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("9a1a5470-2fa6-4c78-8b91-87e352dc1f03"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("9b316990-b93e-4dad-94ba-15a2816ba271"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("9dca9c3e-61e9-4eb2-8309-19d0d1bde74a"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("9e64b535-c352-4ae4-9805-edc1c6bf1dae"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("a0af3858-043a-48fc-b296-a0141378cd64"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("a3b01b5d-0a93-46a4-892b-38ee89ed5989"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("a4ed7e73-c099-488b-8682-32bced889773"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("a5b925a1-0d18-45b5-92e8-ce91e1a00af4"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("a61c559a-dcab-474f-b759-80282613b0c3"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("a8afbdf8-ea44-4339-9f9c-b22fa1853cb6"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("a9e3b776-b7b6-4202-a62d-3543f242c094"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("a9f85745-18c6-4bb6-991a-47f94102dec9"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("aa74160d-fd03-4cc0-8b31-8b2f53fbb3be"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("aab8f3b7-571f-40ff-a902-ba8282feaccc"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("ab55391f-74c1-4e12-991f-49918744fdff"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("ad6c52d9-0265-4c88-bfec-ce9729b07528"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("b2187c8b-5ce1-4e23-a388-fd51632cd69b"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("b2ffd05d-1051-49e0-b588-155414b35b67"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("b353b64f-03f5-48d2-8c95-9b95fadd607b"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("b7bbf975-ae02-4d46-bd37-d3c411f98c93"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("b84d99dd-7efd-4ded-a61a-99def4ccded5"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("b85da6f1-2b1e-4196-85b2-35d516972da6"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("bd7cff12-17ba-4326-9446-013c7b46000f"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("bdb5bf12-0c79-495c-be21-10adf0a1cf0a"), 1, "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.", 11, "https://images.fravega.com/f300/a55db6e62b330fc4768c2bfa9370a5b0.jpg.webp", "Heladera Cíclica GAFA HGF358AFB 282Lts Blanca", 629999m },
                    { new Guid("c0acf26a-1bdf-4eed-b9cc-6d79139a8972"), 1, "Lavarropas con capacidad de 12 Kg, 14 programas de lavado, eficiencia energética A, centrifugado de 750 rpm, función antiarrugas, dispensador automático de detergente, puerta con visor de vidrio templado y panel de control electrónico.", 0, "https://images.fravega.com/f300/bc553a4d53bb5eb5f9e44184047b212b.jpg.webp", "Lavarropas Carga Frontal Drean Next 6 Kg", 679999m },
                    { new Guid("c2dd806c-d4c9-4876-9726-04d22ca54a18"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("c4d11b3d-60f3-451e-bfaf-123f5ba25845"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("c781c3c9-f7ec-4b9b-9d29-6a5de96c20fd"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m },
                    { new Guid("cac4da75-8cd2-436e-b8ef-a27f1e6ed801"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("cfcffb14-94a4-44bc-978f-a3337ebdf593"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("d2c2d780-6198-4eeb-9062-afccd512b5d8"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("d63340f0-79eb-4a84-a142-17a0c6122879"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("d8fd56e2-1293-4fcc-8441-dcd23411e57f"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("dedf990a-9a63-455d-8350-ccdba0d0be12"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("e123dba4-21e4-498d-95f3-620804bf2127"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("e1ffb8d0-0547-48e4-b2c4-0f1d73c81d3d"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("e28516c4-3829-49c4-a9bd-5ac53c500cf4"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("e5eede83-d3aa-43df-bac0-14d048382d7f"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("e7c085b2-868e-4fa6-b2f1-76a64bce481d"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("edb560a7-6304-43cc-96d8-867dc2fec521"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("edbab087-f7d8-4d0d-8461-7a90985d95e8"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("f14a26f3-0688-4949-b241-01719f352d3b"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m },
                    { new Guid("f3511856-639f-4198-b64e-3dd082e135ca"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("f6c925b5-c3d8-4ee7-944c-5844391ecbb3"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("f9dd46d4-b90d-4f20-82da-21b5632c3bae"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("fd4a5c2a-0326-4367-9a1a-415665a1f2bf"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category",
                table: "Product",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Product",
                table: "SaleProduct",
                column: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_Sale",
                table: "SaleProduct",
                column: "Sale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametry");

            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
