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
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductoId);
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
                        principalColumn: "ProductoId",
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
                columns: new[] { "ProductoId", "Category", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("01f3cd25-a66d-47a4-ae34-5f34283ed359"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("0f838257-ea41-4b98-938f-380b8eeffb6a"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("1824f116-da8a-4e6e-8801-bde12d3480c3"), 1, "Aire acondicionado con capacidad de frío de 3000 frigorías y capacidad de calor de 3000 watts. Tecnología Inverter, eficiencia energética A, función de deshumidificación, timer programable, control remoto y modo Sleep.", 5, "https://www.fravega.com/p/aire-acondicionado-split-frio-calor-surrey-3000f-3490w-553bfq1201e--20459/", "Aire Acondicionado Split Surrey Inverter Frio/Calor 3000 F", 1489999m },
                    { new Guid("201bb12f-9780-40b9-86ae-48b61e5bb56b"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("2040d461-02f5-49c2-be7b-4eb438c642a3"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("226b352a-3a49-49ce-8994-4622926396be"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m },
                    { new Guid("2fb85e9f-8546-4d84-a9bc-23e4535fbb66"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("323da16e-26cc-4afc-98fb-e8d695afabcf"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://www.fravega.com.ar/wcsstore/fravega/images/catalog/2023/Febrero/02-02-2023/82JW007LAR-01.jpg", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("33cfed73-dd37-4968-84d8-6286a466a3a6"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("33d15e60-f860-4536-ae9b-4335e92ead82"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("3777f689-d2c4-423c-a895-182ed25f5667"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("38494165-f789-4506-964f-cee6debc6259"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("39fa7e61-6349-454b-872f-b42ee362b3b2"), 1, "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.", 11, "https://images.fravega.com/f300/a55db6e62b330fc4768c2bfa9370a5b0.jpg.webp", "Heladera Cíclica GAFA HGF358AFB 282Lts Blanca", 629999m },
                    { new Guid("4e059cff-8ac9-4421-baec-073b83627976"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("518aeebb-c952-4733-a160-261cd33538c8"), 1, "Lavarropas con capacidad de 12 Kg, 14 programas de lavado, eficiencia energética A, centrifugado de 750 rpm, función antiarrugas, dispensador automático de detergente, puerta con visor de vidrio templado y panel de control electrónico.", 0, "https://images.fravega.com/f300/bc553a4d53bb5eb5f9e44184047b212b.jpg.webp", "Lavarropas Carga Frontal Drean Next 6 Kg", 679999m },
                    { new Guid("55fcc465-704e-4287-998c-bfded3a14d97"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("5aa36dd5-1899-4eee-93b6-81c5c6726349"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("5e2cee25-2243-4f90-ac2d-a9df74551741"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("66ad7a0c-73ad-4120-a620-271f7324f525"), 1, "Lavadora de carga frontal con capacidad de lavado de 10.5 kg. Tecnología EcoBubble que activa el detergente con aire y agua antes de que comience el ciclo de lavado, garantizando una limpieza profunda incluso en agua fría. Eficiencia energética A+++, múltiples programas de lavado, pantalla LED táctil, y sistema de auto-limpieza.", 4, "https://http2.mlstatic.com/D_NQ_NP_910743-MLA73490348656_122023-O.webp", "Lavarropa Samsung Ww10t504daw 10kg Blanco Con Ia Inverter", 2000999m },
                    { new Guid("6cda1640-ec45-48c9-964d-39e386b20448"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("72191b2b-b4a3-485b-a1dd-00c4c46f4f3a"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("73988485-0742-455d-8e52-df3d56cfebc0"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("7d431943-3a01-4733-a5f8-b119b7ffaecc"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("91407ebe-ced2-4d84-a30f-a23ce69df566"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("9ced7950-289d-4e8e-86e6-f733e5cbc6da"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("9d0c45bb-ef9e-4669-95db-b2e773efff79"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("a5944141-8c1a-4a3a-ad7e-492c45f2fb33"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("b97801da-957f-4729-84be-7ed78f167f23"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("c12587ce-e570-47bb-ad01-d5a98de7068a"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("c3d89639-cd7a-4908-af1c-1c78fbd8d83f"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("c89adda0-13ec-46e2-a96a-26c15d5d0170"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("ce53c62d-e77f-43f6-bea4-2a5303f7b251"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("dabb3841-2e67-43e0-b741-6f8c3097a55b"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("dbc63226-819b-4732-8919-8db8bfed915b"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m },
                    { new Guid("e0df1b5a-fefa-4026-9f82-83c1bd2cf0f0"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("ea816fb4-eacd-42aa-9994-b2d6d10cf250"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("eec38ecf-7ac1-4c88-8089-fe2099477533"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("f615213e-07f7-4043-b107-9e42dea29502"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("fe4312d7-8d3c-4f7f-ab01-8f05e99e603a"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("ff42a759-248f-4b2b-997e-ffd3cd2324c6"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m }
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
