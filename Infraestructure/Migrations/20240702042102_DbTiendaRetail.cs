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
                    { 2, "Tecnología y Electrónica" },
                    { 3, "Moda y Accesorios" },
                    { 4, "Hogar y Decoración" },
                    { 5, "Salud y Belleza" },
                    { 6, "Deportes y Ocio" },
                    { 7, "Juguetes y Juegos" },
                    { 8, "Alimentos y Bebidas" },
                    { 9, "Libros y Material Educativo" },
                    { 10, "Jardinería y Bricolaje" }
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
                    { new Guid("0689d15c-35d1-4833-923b-4358877a97d0"), 4, "Este juego de toallas de algodón egipcio es lujoso y absorbente. Perfecto para añadir un toque de elegancia a tu baño. El set incluye toallas de baño, de mano y toallas faciales.", 12, "https://http2.mlstatic.com/D_NQ_NP_935868-MLA76111646337_042024-O.webp", "Juego de toallas de algodón egipcio", 29999m },
                    { new Guid("0e64fb18-bd4c-4e9d-a79a-929c2807c31b"), 5, "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.", 0, "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp", "Crema hidratante facial con ácido hialurónico", 24631m },
                    { new Guid("10499221-7549-4bc0-91b6-79ec56debf2f"), 1, "Lavadora de carga frontal con capacidad de lavado de 10.5 kg. Tecnología EcoBubble que activa el detergente con aire y agua antes de que comience el ciclo de lavado, garantizando una limpieza profunda incluso en agua fría. Eficiencia energética A+++, múltiples programas de lavado, pantalla LED táctil, y sistema de auto-limpieza.", 4, "https://http2.mlstatic.com/D_NQ_NP_910743-MLA73490348656_122023-O.webp", "Lavarropa Samsung Ww10t504daw 10kg Blanco Con Ia Inverter", 2000999m },
                    { new Guid("12a4d047-f748-4425-bfb0-c1829ddc7320"), 2, "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.", 0, "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp", "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA", 573999m },
                    { new Guid("12b750b3-d860-4fb5-bae8-12c27cfac30f"), 8, "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.", 0, "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp", "Galletas de chocolate", 2849m },
                    { new Guid("15b1f0c3-ff75-4789-9194-26023aeab3c8"), 9, "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.", 8, "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp", "Libro de Cocina: Recetas del Mundo", 1999m },
                    { new Guid("1b38086c-c077-4f91-896c-88329591644a"), 3, "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp", "Vestido midi con estampado floral", 19199m },
                    { new Guid("1c099147-f374-4c71-a915-329269775478"), 6, "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!", 8, "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293", "Tabla de Paddle Surf Hinchable Aqua Marina Fusion", 189999m },
                    { new Guid("249db425-4a8c-4cc3-b4f6-746ad2057a27"), 6, "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp", "Juego de mesa para toda la familia", 19061m },
                    { new Guid("2b0ef0a0-7afd-41ab-bed5-225744a7abd8"), 7, "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.", 10, "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp", "Bloques de construcción", 46509m },
                    { new Guid("2bbeec4c-d581-446b-9415-a3264b161830"), 9, "Estos lápices de colores son ideales para que los niños exploren su creatividad.", 0, "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp", "Lápices de colores", 19999m },
                    { new Guid("2d0a0e42-2d3e-4a35-8923-e4ce87fbd2b0"), 10, "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.", 9, "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp", "Kit de Herramientas de Jardinería", 2299m },
                    { new Guid("383ddb14-0b94-4aa2-b862-abbe3a9266e9"), 3, "Las zapatillas deportivas Nike Air Max combinan estilo y comodidad. Con su diseño icónico y tecnología de amortiguación, son perfectas para el uso diario y actividades deportivas.", 0, "https://http2.mlstatic.com/D_NQ_NP_912442-MLA77092906427_062024-O.webp", "Zapatillas deportivas Nike Air Max", 129999m },
                    { new Guid("444ef5da-84e9-447d-b96f-682fef2f44cc"), 5, "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp", "Cepillo de dientes eléctrico sónico", 27953m },
                    { new Guid("4472b7b0-2e85-4762-b04f-009370d61312"), 1, "Microondas con capacidad de 25 litros, potencia de 800W, función de cocina rápida, pantalla LED y botones de control electrónicos.", 2, "https://http2.mlstatic.com/D_NQ_NP_798058-MLU74033812160_012024-O.webp", "Microondas Whirlpool MW 25 BA 25L", 449999m },
                    { new Guid("481ae260-2d71-48e3-9ff6-a19c2e18a066"), 2, "El Apple Watch Series 7 cuenta con una pantalla más grande y avanzada, resistencia al polvo y al agua, y un cargado rápido. Además, incluye funcionalidades de salud y fitness como monitoreo de oxígeno en sangre, ECG y una amplia variedad de aplicaciones deportivas.", 7, "https://http2.mlstatic.com/D_NQ_NP_858093-MLA48096508611_112021-O.webp", "Smartwatch Apple Watch Series 7 GPS 45mm", 529999m },
                    { new Guid("493f5e2a-9088-4f7e-8545-932a11a88236"), 1, "Lavarropas con capacidad de 12 Kg, 14 programas de lavado, eficiencia energética A, centrifugado de 750 rpm, función antiarrugas, dispensador automático de detergente, puerta con visor de vidrio templado y panel de control electrónico.", 0, "https://images.fravega.com/f300/bc553a4d53bb5eb5f9e44184047b212b.jpg.webp", "Lavarropas Carga Frontal Drean Next 6 Kg", 679999m },
                    { new Guid("4ac4a634-f001-4516-8be9-d5e53ec0eb4c"), 10, "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.", 10, "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp", "Kit de herramientas básicas", 65499m },
                    { new Guid("4b763a5a-cea1-4e3f-895b-919308958912"), 3, "Las gafas de sol Ray-Ban Aviator son un clásico atemporal. Con su diseño elegante y lentes polarizados, ofrecen protección UV y estilo. Perfectas para cualquier ocasión.", 20, "https://http2.mlstatic.com/D_NQ_NP_876333-MLA74134571216_012024-O.webp", "Gafas de sol Ray-Ban Aviator", 19999m },
                    { new Guid("4ce62fb7-d796-459e-8487-5ea3fcf96a50"), 6, "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.", 5, "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp", "Bicicleta de montaña", 314689m },
                    { new Guid("4e0cccb5-7f69-430d-9734-5898c59d77a2"), 3, "El gorro de lana tejido es un accesorio esencial para el invierno. Suave y cálido, es perfecto para mantener tu cabeza abrigada y añadir un toque de estilo a tu look.", 0, "https://http2.mlstatic.com/D_NQ_NP_766012-MLA54959307419_042023-O.webp", "Gorro de lana tejido", 9999m },
                    { new Guid("5152eaf7-2c7e-44dc-a547-08f3c0a768bc"), 3, "El cinturón de cuero Calvin Klein es un accesorio sofisticado y versátil. Con su diseño minimalista y elegante, es perfecto para completar cualquier atuendo.", 20, "https://http2.mlstatic.com/D_NQ_NP_913222-MLA77275857767_062024-O.webp", "Cinturón de cuero Calvin Klein", 34999m },
                    { new Guid("5823d761-e70b-400f-b41e-ac683c0dc7ab"), 1, "Aire acondicionado con capacidad de frío de 18000 frigorías y capacidad de calor de 18000 watts. Tecnología Inverter, eficiencia energética A++, función de deshumidificación, timer programable, control remoto y modo Sleep.", 6, "https://http2.mlstatic.com/D_NQ_NP_629906-MLA74780228753_022024-O.webp", "Aire Acondicionado Split LG F-Q186KXA 18000 F", 1999999m },
                    { new Guid("5a3a3106-90d8-41d2-b800-65f07f98c253"), 2, "Los Bose QuietComfort Earbuds ofrecen cancelación de ruido avanzada, sonido de alta calidad y un ajuste cómodo y seguro. Son ideales para disfrutar de tu música sin interrupciones, con una batería de hasta 6 horas de duración.", 8, "https://http2.mlstatic.com/D_NQ_NP_609529-MLU74226371875_012024-O.webp", "Audífonos Bluetooth Bose QuietComfort Earbuds", 199999m },
                    { new Guid("5b771f0d-b062-4264-ad4d-334d91778d00"), 5, "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp", "Maquillaje labial de larga duración", 45490m },
                    { new Guid("5bd07182-4ebd-474f-9409-ae4443a557e8"), 2, "La Bose Smart Soundbar 700 ofrece un sonido inmersivo y conectividad inteligente con Alexa y Google Assistant integrados. Su diseño elegante y su rendimiento acústico superior mejoran cualquier sistema de entretenimiento en el hogar.", 10, "https://http2.mlstatic.com/D_NQ_NP_843862-MLA42478366506_072020-O.webp", "Barra de Sonido Bose Smart Soundbar 700", 399999m },
                    { new Guid("5c313c60-4776-4264-8893-f3aa6bc6f55d"), 2, "El Amazon Echo Dot de 4ta generación con reloj ofrece control por voz con Alexa, sonido mejorado y un diseño elegante. Ideal para gestionar dispositivos inteligentes, reproducir música y obtener información instantánea.", 15, "https://http2.mlstatic.com/D_NQ_NP_907304-MLA76219497482_052024-O.webp", "Bocina Inteligente Amazon Echo Dot 4ta Generación", 49999m },
                    { new Guid("5c3f922c-5d99-4f02-9593-d9cc5778f459"), 1, "Heladera con capacidad total de 505 litros, 342 litros de heladera y 163 litros de freezer. Sistema de frío No Frost, eficiencia energética A++, 4 estrellas de freezer, función de congelamiento rápido, y dispenser de agua y hielo.", 10, "https://http2.mlstatic.com/D_NQ_NP_972873-MLA50008739804_052022-O.webp", "Heladera Side by Side Samsung RS50N3513SL/AA 505Lts", 2499999m },
                    { new Guid("64ce7527-1633-4c1e-8d6e-5d31d50473ca"), 1, "Aire acondicionado con capacidad de frío de 3000 frigorías y capacidad de calor de 3000 watts. Tecnología Inverter, eficiencia energética A, función de deshumidificación, timer programable, control remoto y modo Sleep.", 5, "https://www.fravega.com/p/aire-acondicionado-split-frio-calor-surrey-3000f-3490w-553bfq1201e--20459/", "Aire Acondicionado Split Surrey Inverter Frio/Calor 3000 F", 1489999m },
                    { new Guid("64d627df-249f-4521-822b-5168b01915e2"), 2, "La consola PlayStation 5 de Sony ofrece una experiencia de juego de próxima generación con gráficos impresionantes, tiempos de carga ultrarrápidos y una nueva generación de juegos exclusivos. Su controlador DualSense proporciona una inmersión sin precedentes gracias a su respuesta háptica y gatillos adaptativos.", 0, "https://http2.mlstatic.com/D_NQ_NP_802856-MLU76753493373_052024-O.webp", "Consola PlayStation 5", 1199999m },
                    { new Guid("64f69e22-f82a-417d-b555-c2584d564afb"), 8, "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.", 8, "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp", "Kit de Degustación de Vinos", 4999m },
                    { new Guid("65654ba7-4a3d-4dd6-99b8-b584a864b9a8"), 4, "Esta alfombra de área grande es perfecta para darle un toque de calidez y estilo a tu hogar. Su diseño moderno y colores vibrantes complementarán cualquier decoración.", 3, "https://http2.mlstatic.com/D_NQ_NP_678277-MLA50585725957_072022-O.webp", "Alfombra de área grande", 59999m },
                    { new Guid("6aca5803-849a-4413-9812-4705ccae4149"), 5, "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.", 0, "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp", "Secador de Pelo Profesional Ionic Ceramic", 59299m },
                    { new Guid("747afc75-f14e-4edf-b1e9-e8dfd4eab984"), 1, "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.", 12, "https://http2.mlstatic.com/D_NQ_NP_986989-MLU74218962327_012024-O.webp", "Heladera Cíclica GAFA HGF358AFB 282Lts Inoxidable", 699999m },
                    { new Guid("7531af6d-bda5-493e-8d1f-b441cec55349"), 4, "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.", 10, "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp", "Sofá de dos plazas con diseño moderno", 1000000m },
                    { new Guid("78b2f450-068f-44ef-b27a-ba8e43ea0121"), 9, "Este libro de ficción es una novela apasionante que te atrapará desde el principio.", 0, "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp", "Libro de ficción", 22900m },
                    { new Guid("7eb6003e-3c38-4ad4-a0be-e31766b46924"), 7, "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.", 10, "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp", "Juego de mesa para niños", 44399m },
                    { new Guid("8104ba35-81a6-4304-9426-8547eb97ac92"), 1, "Lavarropas con capacidad de 8 kg, tecnología Inverter, eficiencia energética A++, 14 programas de lavado, función de vapor para eliminar arrugas, y pantalla LED táctil.", 1, "https://http2.mlstatic.com/D_NQ_NP_816984-MLA53496425042_012023-O.webp", "Lavarropas Drean Next 8 Kg Inverter", 749999m },
                    { new Guid("81d92448-b7c6-4f4f-bf93-ef32578e8f95"), 3, "Esta blusa de seda con lazo es perfecta para un look elegante y femenino. Su diseño delicado y tejido suave te harán sentir cómoda y chic en cualquier ocasión.", 0, "https://http2.mlstatic.com/D_NQ_NP_668789-MLA73659925632_012024-O.webp", "Blusa de seda con lazo", 74999m },
                    { new Guid("839db146-dc5c-4d8f-a935-0520dc75fa52"), 2, "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.", 5, "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp", "Smart TV LG 4K UHD 55' UP77", 799999m },
                    { new Guid("83d7e521-2116-41f8-9c53-0a8a2a1d8785"), 7, "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.", 0, "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp", "Muñeca", 27169m },
                    { new Guid("845dcfaf-85a2-4a1c-b56a-e4427c4702c3"), 2, "El monitor curvo de Samsung de 27 pulgadas te ofrece una experiencia inmersiva con su pantalla Full HD y una curvatura 1800R. Con tecnología AMD FreeSync y una frecuencia de actualización de 75 Hz, es ideal para juegos y entretenimiento.", 8, "https://http2.mlstatic.com/D_NQ_NP_904906-MLU69761863493_062023-O.webp", "Monitor Samsung Curvo 27\" Full HD LC27R500FHNXZA", 109999m },
                    { new Guid("8ccf2b77-a963-4f6d-b062-b24462cf386e"), 4, "Esta estantería modular de madera es una solución de almacenamiento versátil y estilosa. Su diseño modular te permite personalizarla según tus necesidades.", 0, "https://http2.mlstatic.com/D_NQ_NP_683332-MLU74725847452_032024-O.webp", "Estantería modular de madera", 45999m },
                    { new Guid("8e7c0ac3-1330-4a28-81fd-aa02589db270"), 1, "Microondas con capacidad de 27 litros, potencia de 1000W, función de cocina rápida, pantalla LED y botones de control electrónicos.", 2, "https://http2.mlstatic.com/D_NQ_NP_858971-MLA74978511181_032024-O.webp", "Microondas Panasonic NN-ST665B 27L", 549999m },
                    { new Guid("8ebd765b-e14f-4ed9-9da6-46987bb34c7f"), 2, "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.", 0, "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp", "Celular Samsung Galaxy S23 Ultra 5G 256GB", 249999m },
                    { new Guid("8f25b002-0cde-4971-aa82-7a9816db12dd"), 3, "La bufanda de lana merino es un accesorio esencial para el invierno. Suave y cálida, es perfecta para mantenerte abrigado con estilo durante los días fríos.", 10, "https://http2.mlstatic.com/D_NQ_NP_744846-MLA76662301416_062024-O.webp", "Bufanda de lana merino", 19999m },
                    { new Guid("90a2eff0-2b2b-45db-8b52-c9225f1eddfb"), 9, "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.", 0, "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp", "Cuaderno de notas", 11990m },
                    { new Guid("91c609c8-cfff-44e8-9c71-50f649ebf8de"), 2, "El JBL Charge 5 es un parlante Bluetooth portátil que ofrece un sonido potente y claro. Con una batería de hasta 20 horas de duración, resistencia al agua y polvo (IP67) y la capacidad de cargar tus dispositivos móviles, es perfecto para llevar tu música a cualquier lugar.", 15, "https://http2.mlstatic.com/D_NQ_NP_778458-MLU72636564641_112023-O.webp", "Parlante Bluetooth JBL Charge 5", 69999m },
                    { new Guid("9aa22ce1-c775-4c0f-8492-7d4f7c660c2a"), 10, "Esta manguera de jardín es perfecta para regar tus plantas y flores.", 10, "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp", "Manguera de jardín", 41582m },
                    { new Guid("9f709330-d2ea-4e32-aaf0-a36d6dec1ede"), 2, "El MacBook Pro de 14 pulgadas con chip M1 Pro de Apple ofrece un rendimiento y eficiencia excepcionales. Con una pantalla Liquid Retina XDR, hasta 32GB de RAM y 1TB de almacenamiento SSD, es ideal para profesionales creativos.", 3, "", "Laptop Apple MacBook Pro 14\" M1 Pro", 2399999m },
                    { new Guid("a337ae0a-5f04-48fa-89cc-0bc93fc42af8"), 7, "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!", 9, "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp", "l", 339999m },
                    { new Guid("a3824796-bfc5-4bb6-8880-3190bd6dc456"), 2, "La nueva iPad Pro de 12.9 pulgadas de Apple ofrece una potencia sin igual gracias a su chip M1. Con 128GB de almacenamiento y una pantalla Liquid Retina XDR, es perfecta para tareas creativas y de productividad. Además, cuenta con un sistema de cámaras avanzadas y compatibilidad con el Apple Pencil y el Magic Keyboard.", 3, "https://http2.mlstatic.com/D_NQ_NP_814559-MLA53970921150_022023-O.webp", "Tablet Apple iPad Pro 12.9\" 128GB Wi-Fi", 1029999m },
                    { new Guid("ae71899c-ea1f-4e2a-8a1c-5fd1d5ad969b"), 2, "La cámara Canon EOS Rebel T7 es perfecta para fotógrafos principiantes. Cuenta con un sensor CMOS de 24.1 MP, pantalla LCD de 3 pulgadas y conectividad Wi-Fi para compartir tus fotos al instante. Además, incluye una lente 18-55mm.", 5, "", "Cámara Canon EOS Rebel T7", 189999m },
                    { new Guid("b0cb9f88-e8ad-4900-a6d2-099328698493"), 3, "El sombrero Fedora de lana es un accesorio clásico y elegante. Perfecto para añadir un toque de estilo a cualquier atuendo, este sombrero es ideal para el otoño e invierno.", 5, "https://http2.mlstatic.com/D_NQ_NP_671496-MLA45427114933_042021-O.webp", "Sombrero Fedora de lana", 29999m },
                    { new Guid("b4508792-22a1-4521-ae23-63fa4580c86c"), 4, "La colcha de cama King size es ideal para agregar un toque de lujo a tu dormitorio. Su diseño elegante y material suave te proporcionarán confort y estilo.", 0, "https://http2.mlstatic.com/D_NQ_NP_934128-MLA48538774826_122021-O.webp", "Colcha de cama King size", 54999m },
                    { new Guid("b54b08a5-a65a-4e2c-a46e-4ea604032066"), 6, "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.", 0, "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp", "Pelota de fútbol", 29890m },
                    { new Guid("b592caeb-06a5-4749-b4a8-456376e67c2e"), 10, "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.", 10, "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp", "Tijeras de podar", 64368m },
                    { new Guid("b96a6657-abe6-4724-bada-3227726461e8"), 4, "Este juego de candelabros de metal es perfecto para crear una atmósfera acogedora en tu hogar. Su diseño elegante y acabado en oro añaden un toque de sofisticación.", 0, "https://http2.mlstatic.com/D_NQ_NP_866208-MLA74951585635_032024-O.webp", "Juego de candelabros de metal", 19999m },
                    { new Guid("bcfb8ca3-be5f-4f2e-9a3f-3b72ee397ae9"), 3, "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.", 0, "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp", "Zapatillas Fila deportivas con plataforma", 79999m },
                    { new Guid("be588d92-9377-4e07-8178-295e804e2149"), 4, "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.", 0, "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp", "Juego de sábanas de algodón 100%", 40999m },
                    { new Guid("c2ac30da-940a-4444-8b96-9192fa57b916"), 4, "Esta lámpara de mesa de diseño es ideal para iluminar tu espacio con estilo. Su base elegante y pantalla de tela proporcionan una luz suave y agradable.", 10, "https://http2.mlstatic.com/D_NQ_NP_747581-MLA73179961416_122023-O.webp", "Lámpara de mesa de diseño", 24999m },
                    { new Guid("c340ebcc-ee75-43e7-9b4f-faa9b9c0caa7"), 2, "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.", 10, "https://http2.mlstatic.com/D_NQ_NP_871625-MLA75823629201_042024-O.webp", "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR", 299999m },
                    { new Guid("c5c4b492-0cc1-43d2-8640-fc0353bd6dc1"), 2, "El DJI Mavic Air 2 es un drone avanzado con una cámara 4K de 48MP, tiempo de vuelo de hasta 34 minutos y múltiples modos de vuelo inteligentes. Perfecto para capturar fotos y videos aéreos de alta calidad.", 0, "https://http2.mlstatic.com/D_NQ_NP_727004-MLA75232255242_032024-O.webp", "Drone DJI Mavic Air 2", 699999m },
                    { new Guid("c72f1c7f-4b62-4656-9a31-9f656c403c6a"), 1, "Lavarropas con capacidad de 12 kg, tecnología Inverter, eficiencia energética A++, 14 programas de lavado, función de vapor para eliminar arrugas, y pantalla LED táctil.", 3, "https://http2.mlstatic.com/D_NQ_NP_742423-MLA51835012835_102022-O.webp", "Lavarropas LG F-1402H5B 12Kg Inverter", 899999m },
                    { new Guid("c96aa170-9bed-44a6-8938-35edad3e8120"), 3, "Los pantalones de mezclilla Levi's 501 son un clásico que nunca pasa de moda. Con su corte recto y ajuste cómodo, son ideales para un look casual y versátil.", 10, "https://http2.mlstatic.com/D_NQ_NP_925069-MLA49693821162_042022-O.webp", "Pantalones de mezclilla Levi's 501", 99999m },
                    { new Guid("cec7d134-208a-4442-afa4-69e2c09fe4da"), 3, "Los botines de cuero marrón son un calzado clásico y atemporal. Con su diseño robusto y elegante, son perfectos para el uso diario y combinan con cualquier atuendo.", 5, "https://http2.mlstatic.com/D_NQ_NP_777105-MLA70924305746_082023-O.webp", "Botines de cuero marrón", 149999m },
                    { new Guid("d1f56722-2c05-44ef-9afb-ae928a026b8f"), 3, "La mochila Jansport clásica es ideal para la escuela o el trabajo. Con amplio espacio de almacenamiento y diseño resistente, ofrece comodidad y durabilidad.", 8, "https://http2.mlstatic.com/D_NQ_NP_967659-MLU70516232392_072023-O.webp", "Mochila Jansport clásica", 59999m },
                    { new Guid("d373d1fd-f8e4-484c-834a-fe7486a24bb8"), 3, "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.", 10, "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp", "Bolso de mano con diseño animal print", 12999m },
                    { new Guid("d489cb8d-6e04-4456-baba-a1fd77bb2a0b"), 3, "La chaqueta de cuero negra es un básico de moda imprescindible. Con su diseño atemporal y ajuste perfecto, es ideal para cualquier ocasión y combina con todo.", 7, "https://http2.mlstatic.com/D_NQ_NP_829598-MLA75171128806_032024-O.webp", "Chaqueta de cuero negra", 249999m },
                    { new Guid("d6621840-55e2-4ff8-b43d-6b76f90c792a"), 2, "La HP OfficeJet Pro 9015e es una impresora multifuncional ideal para oficinas pequeñas y medianas. Ofrece impresión a doble cara, escaneo, copia y fax con alta velocidad y calidad profesional.", 7, "https://http2.mlstatic.com/D_NQ_NP_768300-MLA41233060022_032020-O.webp", "Impresora Multifuncional HP OfficeJet Pro 9015e", 229999m },
                    { new Guid("da1c918e-0d4c-41be-a219-dbf1d4e25c45"), 4, "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.", 8, "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp", "Set de 3 Cuadros Decorativos Modernos", 8999m },
                    { new Guid("da584d40-8c9d-41e1-8b8c-20dab49f8a73"), 2, "El router ASUS RT-AX86U es ideal para juegos y transmisión en 4K. Ofrece tecnología WiFi 6 con velocidades de hasta 5700 Mbps, puerto gaming de 2.5 Gbps y seguridad AiProtection Pro.", 12, "https://http2.mlstatic.com/D_NQ_NP_760437-MLU76150445423_052024-O.webp", "Router WiFi 6 ASUS RT-AX86U", 199999m },
                    { new Guid("dc847166-4337-403a-879d-6515c71158dc"), 3, "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.", 5, "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp", "Cafetera Espresso De'Longhi Dedica", 82999m },
                    { new Guid("dd43bca7-9cc0-4566-a34e-e5f6a4a662e3"), 2, "La Ring Stick Up Cam Battery es una cámara de seguridad versátil para interiores y exteriores. Ofrece video HD 1080p, detección de movimiento, visión nocturna y comunicación bidireccional. Funciona con batería recargable o alimentación solar.", 10, "https://http2.mlstatic.com/D_NQ_NP_968604-MLA73899541113_012024-O.webp", "Cámara de Seguridad Ring Stick Up Cam Battery", 89999m },
                    { new Guid("de0f12b2-bc20-46a8-9616-8a352341532b"), 2, "Los auriculares Sony WH-1000XM4 ofrecen una cancelación de ruido líder en la industria, un sonido excepcional y comodidad durante todo el día. Con una batería de larga duración y características inteligentes como el control táctil y el Speak-to-Chat, son ideales para disfrutar de tu música sin interrupciones.", 12, "https://http2.mlstatic.com/D_NQ_NP_918604-MLA44483909501_012021-O.webp", "Auriculares Inalámbricos Sony WH-1000XM4", 149999m },
                    { new Guid("de2d73dd-e5d4-428c-9633-a5140aa1dfb8"), 3, "El bolso tote de tela es práctico y estiloso. Con amplio espacio de almacenamiento y un diseño moderno, es perfecto para llevar tus esenciales diarios.", 15, "https://http2.mlstatic.com/D_NQ_NP_949148-MLU75692429655_042024-O.webp", "Bolso tote de tela", 44999m },
                    { new Guid("e58fb3a3-92c6-42b3-990a-b286dcd9cea3"), 4, "Esta mesa de centro de madera y metal combina estilo industrial y funcionalidad. Es perfecta para complementar la decoración de tu sala de estar.", 0, "https://http2.mlstatic.com/D_NQ_NP_867489-MLA74928886215_032024-O.webp", "Mesa de centro de madera y metal", 89999m },
                    { new Guid("e98ac605-9a63-4a1f-aa65-f45f61061076"), 4, "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.", 5, "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp", "Juego de vajilla para 6 personas", 34879m },
                    { new Guid("eb559725-26d8-416f-96f6-98b9e4885190"), 1, "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.", 11, "https://images.fravega.com/f300/a55db6e62b330fc4768c2bfa9370a5b0.jpg.webp", "Heladera Cíclica GAFA HGF358AFB 282Lts Blanca", 629999m },
                    { new Guid("edfc8451-3709-4cfd-adb5-94dc06a62cdb"), 4, "Las cortinas blackout de lino son perfectas para mantener la privacidad y bloquear la luz no deseada. Su tejido de alta calidad y diseño elegante mejorarán cualquier habitación.", 5, "https://http2.mlstatic.com/D_NQ_NP_888846-MLA69964681489_062023-O.webp", "Cortinas blackout de lino", 32999m },
                    { new Guid("f0a370c5-86ee-46e2-b64e-92f405879a26"), 8, "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.", 0, "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg", "Manzanas frescas", 2999m },
                    { new Guid("f1586e1d-7d7b-4de5-a8fa-49db28a84019"), 4, "La planta artificial decorativa es perfecta para agregar un toque de verde a tu hogar sin necesidad de mantenimiento. Su diseño realista complementará cualquier decoración.", 0, "https://http2.mlstatic.com/D_NQ_NP_611532-MLA72597798496_112023-O.webp", "Planta artificial decorativa", 15999m },
                    { new Guid("f298d0b0-3583-4931-b14f-3b6e407f5fd0"), 4, "El espejo de pared grande es un accesorio esencial para cualquier hogar. Su diseño elegante y marco robusto lo convierten en una pieza decorativa y funcional.", 5, "https://http2.mlstatic.com/D_NQ_NP_983208-MLU75985619618_052024-O.webp", "Espejo de pared grande", 78999m },
                    { new Guid("f491475c-666f-4efc-8d6e-c5e4c2f63221"), 2, "El proyector Epson Home Cinema 2150 ofrece una experiencia de cine en casa con resolución Full HD 1080p, 2500 lúmenes de brillo y conectividad inalámbrica. Perfecto para ver películas y jugar videojuegos en gran pantalla.", 6, "https://http2.mlstatic.com/D_NQ_NP_650108-MLA74903080735_032024-O.webp", "Proyector Epson Home Cinema 2150", 299999m },
                    { new Guid("f552a825-cac9-435e-a10f-2c0ef24c5892"), 3, "La cartera de cuero Michael Kors es un accesorio elegante y práctico. Con múltiples compartimentos y un diseño sofisticado, es perfecta para llevar tus esenciales con estilo.", 12, "https://http2.mlstatic.com/D_NQ_NP_990693-MLA74704426792_022024-O.webp", "Cartera de cuero Michael Kors", 159999m },
                    { new Guid("f62ad1ae-421e-4bcb-9f7d-06f389848b3e"), 8, "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.", 0, "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp", "Leche descremada", 1790m },
                    { new Guid("f7c6677b-4922-449e-9cdc-af18270a575a"), 3, "El Apple Watch Series 6 es un accesorio moderno y funcional. Con monitoreo de salud, GPS, y múltiples aplicaciones, es perfecto para mantenerte conectado y saludable.", 15, "https://http2.mlstatic.com/D_NQ_NP_792553-MLU73159525351_112023-O.webp", "Reloj inteligente Apple Watch Series 6", 499999m },
                    { new Guid("fc129924-d674-48d2-844b-f77b3fc92cd2"), 3, "Esta falda plisada midi es elegante y versátil. Con su diseño femenino y tejido ligero, es perfecta para cualquier ocasión, desde el trabajo hasta eventos especiales.", 8, "https://http2.mlstatic.com/D_NQ_NP_713957-MLA70114688153_062023-O.webp", "Falda plisada midi", 59999m }
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
