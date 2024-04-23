using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Parametries",
                columns: table => new
                {
                    ParametriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametries", x => x.ParametriaId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProducts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProducts", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_SaleProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProducts_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
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
                table: "Parametries",
                columns: new[] { "ParametriaId", "Codigo", "Value" },
                values: new object[] { 1, "taxe_iva", 21m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductoId", "Description", "Discount", "Name", "Price", "UrlImage", "categoryId" },
                values: new object[,]
                {
                    { new Guid("00d96e24-6072-4609-8944-ef7d71c43799"), "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "Libro de ficción", 22900m, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", 9 },
                    { new Guid("02acf71c-7d89-41f5-81fb-1244e41f96f7"), "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "Crema hidratante facial con ácido hialurónico", 24631m, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", 5 },
                    { new Guid("036e7897-33dd-4efd-ab74-7a8d8727875b"), "Lavarropas con capacidad de 12 Kg, 14 programas de lavado, eficiencia energética A, centrifugado de 750 rpm, función antiarrugas, dispensador automático de detergente, puerta con visor de vidrio templado y panel de control electrónico.", 0, "Lavarropas Carga Frontal Drean Next 6 Kg", 679999m, "https://images.fravega.com/f300/bc553a4d53bb5eb5f9e44184047b212b.jpg.webp", 1 },
                    { new Guid("0a57991d-da98-418a-8728-4380136fbf0e"), "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "Cafetera Espresso De'Longhi Dedica", 82999m, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", 3 },
                    { new Guid("1a06e3f7-a838-4e9c-bc7b-67017b671f7b"), "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "Lápices de colores", 19999m, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", 9 },
                    { new Guid("343f757d-bc57-4e10-a3b9-1c31d22f2487"), "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "Bloques de construcción", 46509m, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", 7 },
                    { new Guid("37badf2e-2f3d-4e34-a764-b63ce93b3112"), "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "Vestido midi con estampado floral", 19199m, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", 3 },
                    { new Guid("39b877d6-6826-4a2d-9184-62dc77a9f485"), "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "Zapatillas Fila deportivas con plataforma", 79999m, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", 3 },
                    { new Guid("4a4b7071-c4a7-4ddf-b579-f87cbcda6ac7"), "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "Juego de vajilla para 6 personas", 34879m, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", 4 },
                    { new Guid("4bc5aaf0-074c-46c1-88b3-2bc2a2118e52"), "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "Manzanas frescas", 2999m, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", 8 },
                    { new Guid("4da52bb9-42a2-4f3c-8928-8a0d04f5f802"), "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "Set de 3 Cuadros Decorativos Modernos", 8999m, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", 4 },
                    { new Guid("4e0e6517-9a98-49a3-8399-18a6a83577af"), "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "Kit de herramientas básicas", 65499m, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", 10 },
                    { new Guid("63af7491-4d17-4080-8120-401eb6c9971a"), "Lavadora de carga frontal con capacidad de lavado de 10.5 kg. Tecnología EcoBubble que activa el detergente con aire y agua antes de que comience el ciclo de lavado, garantizando una limpieza profunda incluso en agua fría. Eficiencia energética A+++, múltiples programas de lavado, pantalla LED táctil, y sistema de auto-limpieza.", 4, "Lavarropa Samsung Ww10t504daw 10kg Blanco Con Ia Inverter", 2000999m, "https://http2.mlstatic.com/D_NQ_NP_910743-MLA73490348656_122023-O.webp", 1 },
                    { new Guid("6ab3185d-3541-461f-849c-23b306788e39"), "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "Cuaderno de notas", 11990m, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", 9 },
                    { new Guid("738cfa6e-dbf8-40a7-8dc8-22db03798d58"), "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", 2 },
                    { new Guid("7ca8c055-7659-4309-a2b1-91074e05932c"), "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "Galletas de chocolate", 2849m, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", 8 },
                    { new Guid("80a6ddf3-6dfa-448d-bbf1-54ff6deb4c26"), "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "Pelota de fútbol", 29890m, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", 6 },
                    { new Guid("82b55041-b7de-4683-b094-f4c417297570"), "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "Muñeca", 27169m, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", 7 },
                    { new Guid("8fd25588-9fda-466c-8510-432b6f32fb10"), "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "Tijeras de podar", 64368m, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", 10 },
                    { new Guid("90867a7e-0c9d-4de6-980a-45b50ef5ba4d"), "Aire acondicionado con capacidad de frío de 3000 frigorías y capacidad de calor de 3000 watts. Tecnología Inverter, eficiencia energética A, función de deshumidificación, timer programable, control remoto y modo Sleep.", 5, "Aire Acondicionado Split Surrey Inverter Frio/Calor 3000 F", 1489999m, "https://www.fravega.com/p/aire-acondicionado-split-frio-calor-surrey-3000f-3490w-553bfq1201e--20459/", 1 },
                    { new Guid("a37a7be1-5fe4-4e95-bd0f-bef9711194ea"), "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "Libro de Cocina: Recetas del Mundo", 1999m, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", 9 },
                    { new Guid("a5d55beb-dfc7-4796-a691-56f83274fead"), "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", 2 },
                    { new Guid("ab47bd74-ec15-44d6-9dfc-36fad4c5e97b"), "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "Juego de mesa para niños", 44399m, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", 7 },
                    { new Guid("afac0a93-d08d-4a5e-ae46-2ec16ec69e6c"), "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "Manguera de jardín", 41582m, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", 10 },
                    { new Guid("bb089c1b-4819-48a9-acbd-bdadf16cddb7"), "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", 6 },
                    { new Guid("bcbd2bbc-40bf-4a62-930f-a3c269a6b3b4"), "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "Juego de sábanas de algodón 100%", 40999m, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", 4 },
                    { new Guid("bdc6f74d-344b-45d7-b03e-4541f2a1e0ad"), "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "Secador de Pelo Profesional Ionic Ceramic", 59299m, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", 5 },
                    { new Guid("cbb29284-7653-42e2-bb40-cddb4af8bc04"), "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m, "https://www.fravega.com.ar/wcsstore/fravega/images/catalog/2023/Febrero/02-02-2023/82JW007LAR-01.jpg", 2 },
                    { new Guid("ccfbfecd-16a6-4e9f-bf00-b4cf910af836"), "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "Cepillo de dientes eléctrico sónico", 27953m, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", 5 },
                    { new Guid("da1d1489-590f-4763-831a-c7bb38563ef9"), "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "Kit de Degustación de Vinos", 4999m, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", 8 },
                    { new Guid("e02fdd8a-4207-476b-bdff-0e51e02176c6"), "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "Smart TV LG 4K UHD 55' UP77", 799999m, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", 2 },
                    { new Guid("e323aa91-4ee2-4af8-9f45-2438a00ff787"), "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "Juego de mesa para toda la familia", 19061m, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", 6 },
                    { new Guid("edf4669e-ddba-4851-a6c0-fd3e32d62083"), "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "Bicicleta de montaña", 314689m, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", 6 },
                    { new Guid("eeb407e8-1cc7-4498-80e6-68a868ee34b9"), "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "Sofá de dos plazas con diseño moderno", 1000000m, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", 4 },
                    { new Guid("f5deb667-4d0f-4ac8-8b91-9d38ee616893"), "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "Leche descremada", 1790m, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", 8 },
                    { new Guid("f727bcaf-b030-4704-97f9-1d80b1e786fb"), "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "Kit de Herramientas de Jardinería", 2299m, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", 10 },
                    { new Guid("f8dba80d-4ba4-4d96-866f-6a7669a7d5d9"), "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.", 11, "Heladera Cíclica GAFA HGF358AFB 282Lts Blanca", 629999m, "https://images.fravega.com/f300/a55db6e62b330fc4768c2bfa9370a5b0.jpg.webp", 1 },
                    { new Guid("f9bc7722-96ef-41d0-b762-91871d8546d2"), "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "l", 339999m, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", 7 },
                    { new Guid("fad6d03a-904c-47af-a008-08e1dec882d7"), "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "Maquillaje labial de larga duración", 45490m, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", 5 },
                    { new Guid("fc8bf7ea-f922-424b-923c-56dffec78e05"), "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "Bolso de mano con diseño animal print", 12999m, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProducts_ProductId",
                table: "SaleProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProducts_SaleId",
                table: "SaleProducts",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametries");

            migrationBuilder.DropTable(
                name: "SaleProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
