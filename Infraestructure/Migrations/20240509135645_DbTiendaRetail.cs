using System;
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
                    { new Guid("01eed05a-694f-4e12-ad03-55d489149abd"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("0a1706db-eb15-4de2-bfbc-6e56ae1be039"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("0fc647c6-b06e-4e60-9f6c-d0736e8da0e9"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://www.fravega.com.ar/wcsstore/fravega/images/catalog/2023/Febrero/02-02-2023/82JW007LAR-01.jpg", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("11f64468-2667-4146-b6ab-dba9fb122fb1"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m },
                    { new Guid("20685961-1fa3-4f9a-a53b-c6adcf5f9821"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("2ecabb97-02e9-444f-8e5a-ff9b1431c4ff"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("37eb87a9-ba76-42c4-b25e-b309f389e2d2"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("3d63c9a2-7793-4106-98d8-66b89f3ef7a0"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("46d08b71-8534-4c96-a932-75a93cbf2f1a"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("4b4e92f7-b410-4c86-9a1b-15e8ba65b812"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("4cb4394b-2c67-417a-b4e2-28970bae5c78"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("503d478e-b0e3-4342-bb4f-ca3ebc53e0d2"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("523c2790-da82-4e8a-9797-a1b6753e39d2"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("5cebb56c-81e3-40f4-b72b-5a3a12c4fee2"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("61e67677-6c71-4c25-a23d-629a64e0d21c"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("66776f20-ced4-492b-856f-ea7ab87282b2"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("68954802-df19-4a60-b8af-ff41ebe9d7c7"), 1, "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.", 11, "https://images.fravega.com/f300/a55db6e62b330fc4768c2bfa9370a5b0.jpg.webp", "Heladera Cíclica GAFA HGF358AFB 282Lts Blanca", 629999m },
                    { new Guid("6f7b9d6d-1853-4035-b71c-fadfe67e69c3"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("7235607e-9a26-417d-aec1-a85e5ed68546"), 1, "Lavadora de carga frontal con capacidad de lavado de 10.5 kg. Tecnología EcoBubble que activa el detergente con aire y agua antes de que comience el ciclo de lavado, garantizando una limpieza profunda incluso en agua fría. Eficiencia energética A+++, múltiples programas de lavado, pantalla LED táctil, y sistema de auto-limpieza.", 4, "https://http2.mlstatic.com/D_NQ_NP_910743-MLA73490348656_122023-O.webp", "Lavarropa Samsung Ww10t504daw 10kg Blanco Con Ia Inverter", 2000999m },
                    { new Guid("73c79e59-60d8-443d-9588-ce5849f5513b"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("84c2c476-d2da-4dfe-a106-fc66940bb11f"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("89db469f-9ad3-4f81-81a4-55e7aa4f391e"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("9040c042-e536-4c15-badd-e8cfc335fe8a"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("940e270a-a9c0-45c8-ba02-42b578b5fd35"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("9e760191-07e7-4d58-9884-a6a617001ee4"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("a23436b2-63bc-43a9-b5ff-adb2280caf2b"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("a2daf8f7-6ac5-4c33-a87b-0a5585ce28d4"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m },
                    { new Guid("a57d1ab9-ddee-4d5a-9981-e4a64ad7ec63"), 1, "Aire acondicionado con capacidad de frío de 3000 frigorías y capacidad de calor de 3000 watts. Tecnología Inverter, eficiencia energética A, función de deshumidificación, timer programable, control remoto y modo Sleep.", 5, "https://www.fravega.com/p/aire-acondicionado-split-frio-calor-surrey-3000f-3490w-553bfq1201e--20459/", "Aire Acondicionado Split Surrey Inverter Frio/Calor 3000 F", 1489999m },
                    { new Guid("a79e4ba1-876c-498a-8d5e-975d365e9c17"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("a95eb30b-db25-4f1d-94d2-d867435d60c9"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m },
                    { new Guid("aa93dbf2-b7f3-4320-9f3e-88715b53741c"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("ab1cc39e-0687-4dc6-9836-aaf5c0a5f684"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("b5b883b3-7c9b-46c3-9fae-4f63657892c4"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("b7130e6d-afc9-44bb-9e24-c19e24b7ada7"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("b7716299-7c42-4c32-b4b1-29cf7589792c"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("ba5dfb09-1705-4acc-bed2-7e67b9b53a03"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("c992b132-a970-4992-9bec-52c12508d26f"), 1, "Lavarropas con capacidad de 12 Kg, 14 programas de lavado, eficiencia energética A, centrifugado de 750 rpm, función antiarrugas, dispensador automático de detergente, puerta con visor de vidrio templado y panel de control electrónico.", 0, "https://images.fravega.com/f300/bc553a4d53bb5eb5f9e44184047b212b.jpg.webp", "Lavarropas Carga Frontal Drean Next 6 Kg", 679999m },
                    { new Guid("cc3e7a92-16e6-4956-b8b1-36d61f393975"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("d6eb3e2f-4f1b-432e-b0ec-b9c403b6d5ad"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("ed17203e-d9a4-4245-bc00-c6daa9e9acd8"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m }
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
