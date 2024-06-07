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
                    { new Guid("020068c1-f5d2-4290-a906-ed95d7d5b055"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("03e3922a-70f7-48d7-8a8f-6361b55ec2db"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("05aa4944-705b-4397-bb82-dac21fa4c9c0"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://www.fravega.com.ar/wcsstore/fravega/images/catalog/2023/Febrero/02-02-2023/82JW007LAR-01.jpg", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("06754372-12b8-41e6-9396-40cffb86594e"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("067fde6a-c792-45a7-accc-befc18d9833a"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("08ad5c35-2ac9-4d93-9334-a47508209061"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("0c22a510-add2-4b95-9f52-8793fcb696c2"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("1346f58f-54fb-4b89-9b70-f07d0e6909da"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("13c4b683-d39a-4120-9a1e-0b3c8b030656"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("16b18263-b489-428d-bdb6-f14b5fa6b261"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("18896fb8-1aad-44f6-9db1-849e9a33d264"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("1a53cdc4-10da-4743-8621-1988c4ef2873"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("1d49f55f-30b1-4db5-8282-010aa05b16a0"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://www.fravega.com.ar/wcsstore/fravega/images/catalog/2023/Febrero/02-02-2023/82JW007LAR-01.jpg", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("1e63b871-1792-4c87-9a4d-5bda9e45d52b"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("246ed521-cfa2-4e64-a906-92db26a721bf"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("2552fdf2-32d3-4d52-9562-7a0f9c888d78"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m },
                    { new Guid("2a4c477e-96c4-49a0-8970-ab3aaa45d920"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("2c2e08a6-c282-4893-8e59-aaf999ca7178"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("2d8c7a41-d8d2-45c8-81a1-5f15e1a4aefa"), 1, "Aire acondicionado con capacidad de frío de 3000 frigorías y capacidad de calor de 3000 watts. Tecnología Inverter, eficiencia energética A, función de deshumidificación, timer programable, control remoto y modo Sleep.", 5, "https://www.fravega.com/p/aire-acondicionado-split-frio-calor-surrey-3000f-3490w-553bfq1201e--20459/", "Aire Acondicionado Split Surrey Inverter Frio/Calor 3000 F", 1489999m },
                    { new Guid("374b3911-e69e-482e-9f06-490809a48288"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("391fe6bd-81f0-4d3e-86bf-41b868de49fd"), 1, "Lavarropas con capacidad de 12 Kg, 14 programas de lavado, eficiencia energética A, centrifugado de 750 rpm, función antiarrugas, dispensador automático de detergente, puerta con visor de vidrio templado y panel de control electrónico.", 0, "https://images.fravega.com/f300/bc553a4d53bb5eb5f9e44184047b212b.jpg.webp", "Lavarropas Carga Frontal Drean Next 6 Kg", 679999m },
                    { new Guid("3e405c97-ce8d-4b0d-b666-076e5b000a8e"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("3f329579-9f38-4324-ab5a-5f51709a4746"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("421f0e62-4e6e-4e19-b25f-1dbef5638785"), 1, "Lavadora de carga frontal con capacidad de lavado de 10.5 kg. Tecnología EcoBubble que activa el detergente con aire y agua antes de que comience el ciclo de lavado, garantizando una limpieza profunda incluso en agua fría. Eficiencia energética A+++, múltiples programas de lavado, pantalla LED táctil, y sistema de auto-limpieza.", 4, "https://http2.mlstatic.com/D_NQ_NP_910743-MLA73490348656_122023-O.webp", "Lavarropa Samsung Ww10t504daw 10kg Blanco Con Ia Inverter", 2000999m },
                    { new Guid("42a9ca2b-15ed-4433-8df2-3cf090bacccf"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("450868fb-95b7-4e28-bf86-2b29aee2d143"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("48c6b0ce-5e99-418f-8556-5662d3e8b7a6"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("49decd1e-d1b2-481a-bb9e-10dbf42a0282"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("49e5a750-ac44-400c-babb-19a996b364d0"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("4b739e59-d143-4907-8e52-c4f24de329b6"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("4c27ba23-8426-49d6-a92c-7b39aac60104"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("4e9b15ec-756c-46e3-befe-2381f0db92dd"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("539db988-21b3-4d97-a6f3-30a039214c61"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("555a8d23-554a-4c2b-a432-6bdedfabb116"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("555ff85e-40e4-4007-9099-39330335e487"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("562f15f0-c18e-4fb0-aece-4d607608bd3b"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("5654fb28-3cab-4522-a7ae-08d3eac9a7d4"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("587d9724-27c6-484c-9538-614498cf252b"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("5a95261d-7c5f-407a-9049-05916c52b103"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("5ab9a6ee-a4ef-4ae3-8f2d-a25af1b557d3"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("5c91b127-b0a2-40e0-887e-739f48f8993c"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m },
                    { new Guid("5cd81d79-59fe-49f5-ab32-e1d84a63f630"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("6178dad1-b05e-4d1c-9881-dfa66b5c9865"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("61d989b9-55b8-4542-b936-ce48576fb727"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("62928705-3d65-4d4b-9d64-ab50cdf0e391"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("639fa8a9-3ec4-44fa-bfd7-1d7afa644911"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://www.fravega.com.ar/wcsstore/fravega/images/catalog/2023/Febrero/02-02-2023/82JW007LAR-01.jpg", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("64495d40-7d29-49a7-bf54-712fba99cbf5"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("6728d1c4-425c-42b2-bc04-bfdd4473a26b"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("6853c6d4-8968-4b38-9d70-0adf00409c44"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m },
                    { new Guid("6886c212-34ae-47d6-9895-024c71679c2e"), 1, "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.", 11, "https://images.fravega.com/f300/a55db6e62b330fc4768c2bfa9370a5b0.jpg.webp", "Heladera Cíclica GAFA HGF358AFB 282Lts Blanca", 629999m },
                    { new Guid("689675be-b8ee-4cd6-bee6-79c2477de649"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("68b6f9b0-ac7b-469c-ae19-f501dcca2dce"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("68dfd47e-cb0b-47ff-8089-832e06d29422"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("6912c5ff-82f4-4de9-b06b-7ab54c5bb2b7"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("71524f18-34c5-4835-bc5f-88b70bde4340"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("727a9b41-2e29-4006-b4ed-66d69692df83"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("732fb105-77d3-41e2-8246-c10f1dbbfb29"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("7444b4dc-bc75-4186-ba35-88303b5a0cb8"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("74c73272-4ab8-434f-a728-e822a39f96a4"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("766e01a5-d473-4dd3-ad5e-fdf7e711de98"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("7900349a-092a-452b-a132-b6b0ddb13fd4"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("7a51d6a8-3139-4ae7-8634-101d38500d83"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("84bffe43-13a3-43f5-8c7d-d86d81787a62"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("85ec14ff-1673-4a10-af72-115ff87f9605"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("86436f1e-b8d1-45b9-955d-7013910894a6"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("86b35554-3a2d-447d-b28b-f242e2f91106"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("898c64a1-9468-432e-8710-6e4ddeb45ec5"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("8990e979-c4ef-4f70-81f4-84f6d0d866fe"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("8ac967ba-3f35-4d7f-9234-216b83291e0a"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("8db28a8e-51ef-43ae-9d53-403b08e7e982"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("92c0693d-dce4-4dce-b3bc-beede3217330"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("92df43c4-c332-420a-8d6c-7af3be2e590b"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("940f37db-9d3c-400e-80ad-378f52e3ad71"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("94533af4-fa19-4013-a684-b5f8a9f7b04e"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("9b970e0c-2c94-460a-a2e2-fe2f2aa98258"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("9cce47a3-fac7-46d5-88f5-4dbb952cd71b"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("9e4dc5b8-3461-495d-9e61-af836768be70"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("a08e7afc-ae25-4f08-b48c-d39ec8a582a6"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("a4df1bbd-169a-40aa-a62b-bcaf53f4a17e"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("b0f2ffd5-bae7-43e7-bf38-943edb452c7f"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("b11b3487-4f8c-4d2a-8702-21d481c9356d"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("b3fd014c-46a9-437e-ba76-01fa5e6b1762"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m },
                    { new Guid("b4be5d6a-3b09-4883-b671-bc545013077d"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("b5326ea4-5926-4e7b-9e3e-3f9c26405108"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("b6db4957-2138-4b04-87a1-d3a78357c28d"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("b79e6d9d-1529-4d4b-88c4-f5975a129973"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("bcc603c1-40c7-46c4-85e2-99f5517743dd"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("c02c6d85-1d3d-458f-b5cc-99d8e9ed02a9"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("c5acf62b-305a-4bc8-9aee-a534c8a6d32f"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("c68afdfd-1fb9-41f6-bfee-8a5d2a899846"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("cb64fc5c-b1d9-4a10-ac7d-ae5ad21cd993"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m },
                    { new Guid("cf521447-cf31-4c1d-b11e-6d2a16e864ef"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("d1dcf6c0-782d-4f44-89c8-8f8e0dd21e1d"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("d61139e0-9825-4c43-9e55-19f016b58941"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m },
                    { new Guid("d6fa39dd-cf8b-4dc9-9aa3-ec4204d80dd4"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("d8acb384-fa5f-44ee-8f21-b17f533ef098"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("dafa9957-9bc2-43f8-8bf6-8094281de0fb"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("dc513d25-5aae-402c-a0b4-ac542aa6f9cf"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("dc7c4da6-018f-4554-ad6c-83d6e7f4fd24"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("dcc934be-1509-4e13-9f31-31feba2040a5"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m },
                    { new Guid("dd61b4ed-5368-464d-b68f-91425530c20a"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("ded53ea1-715d-45cd-b770-74474b7f185c"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("e03c768f-9022-47fd-b641-3c3507cf189d"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("e2fe8dea-cac4-49c9-a991-dd4b36e77914"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("e89324eb-331a-4cc4-a72b-5bbdc83c6dc1"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("ea2e7b8d-f88b-4fcc-9fd6-94892e7d2f60"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("eb3bef5b-762e-4648-a23c-0e54b2b2a867"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("eb47e222-8fcf-41ec-bf38-c69b677017cd"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("edbd1147-a7dc-44ca-a04f-ff207039185d"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("ef03c4ec-b8c1-4cb8-93c9-8fc53e82e533"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m },
                    { new Guid("f01f0a16-675f-48ef-bd39-fec54b708cb8"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("f2d6de35-a8a6-4e0a-9cb4-8274de541cb4"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("f9941b2e-6c7f-4f38-bdeb-974dc1158c3d"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m }
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
