﻿// <auto-generated />
using System;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entitys.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Electrodomésticos"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Tecnologia y Electrónica"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Moda y Accesorios"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Hogar y Decoración"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Salud y Belleza"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Deportes y Ocio"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Juguetes y Juegos"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "Alimentos y Bebidas"
                        },
                        new
                        {
                            CategoryId = 9,
                            Name = "Libros y Material Eductivo"
                        },
                        new
                        {
                            CategoryId = 10,
                            Name = "Jardineria y Bricola"
                        });
                });

            modelBuilder.Entity("Domain.Entitys.Parametry", b =>
                {
                    b.Property<int>("ParametriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParametriaId"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ParametriaId");

                    b.ToTable("Parametries");

                    b.HasData(
                        new
                        {
                            ParametriaId = 1,
                            Codigo = "taxe_iva",
                            Value = 21m
                        });
                });

            modelBuilder.Entity("Domain.Entitys.Product", b =>
                {
                    b.Property<Guid>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.HasIndex("categoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            ProductoId = new Guid("036e7897-33dd-4efd-ab74-7a8d8727875b"),
                            Description = "Lavarropas con capacidad de 12 Kg, 14 programas de lavado, eficiencia energética A, centrifugado de 750 rpm, función antiarrugas, dispensador automático de detergente, puerta con visor de vidrio templado y panel de control electrónico.",
                            Discount = 0,
                            Name = "Lavarropas Carga Frontal Drean Next 6 Kg",
                            Price = 679999m,
                            UrlImage = "https://images.fravega.com/f300/bc553a4d53bb5eb5f9e44184047b212b.jpg.webp",
                            categoryId = 1
                        },
                        new
                        {
                            ProductoId = new Guid("f8dba80d-4ba4-4d96-866f-6a7669a7d5d9"),
                            Description = "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.",
                            Discount = 11,
                            Name = "Heladera Cíclica GAFA HGF358AFB 282Lts Blanca",
                            Price = 629999m,
                            UrlImage = "https://images.fravega.com/f300/a55db6e62b330fc4768c2bfa9370a5b0.jpg.webp",
                            categoryId = 1
                        },
                        new
                        {
                            ProductoId = new Guid("90867a7e-0c9d-4de6-980a-45b50ef5ba4d"),
                            Description = "Aire acondicionado con capacidad de frío de 3000 frigorías y capacidad de calor de 3000 watts. Tecnología Inverter, eficiencia energética A, función de deshumidificación, timer programable, control remoto y modo Sleep.",
                            Discount = 5,
                            Name = "Aire Acondicionado Split Surrey Inverter Frio/Calor 3000 F",
                            Price = 1489999m,
                            UrlImage = "https://www.fravega.com/p/aire-acondicionado-split-frio-calor-surrey-3000f-3490w-553bfq1201e--20459/",
                            categoryId = 1
                        },
                        new
                        {
                            ProductoId = new Guid("63af7491-4d17-4080-8120-401eb6c9971a"),
                            Description = "Lavadora de carga frontal con capacidad de lavado de 10.5 kg. Tecnología EcoBubble que activa el detergente con aire y agua antes de que comience el ciclo de lavado, garantizando una limpieza profunda incluso en agua fría. Eficiencia energética A+++, múltiples programas de lavado, pantalla LED táctil, y sistema de auto-limpieza.",
                            Discount = 4,
                            Name = "Lavarropa Samsung Ww10t504daw 10kg Blanco Con Ia Inverter",
                            Price = 2000999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_910743-MLA73490348656_122023-O.webp",
                            categoryId = 1
                        },
                        new
                        {
                            ProductoId = new Guid("738cfa6e-dbf8-40a7-8dc8-22db03798d58"),
                            Description = "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.",
                            Discount = 0,
                            Name = "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA",
                            Price = 573999m,
                            UrlImage = "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp",
                            categoryId = 2
                        },
                        new
                        {
                            ProductoId = new Guid("a5d55beb-dfc7-4796-a691-56f83274fead"),
                            Description = "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.",
                            Discount = 0,
                            Name = "Celular Samsung Galaxy S23 Ultra 5G 256GB",
                            Price = 249999m,
                            UrlImage = "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp",
                            categoryId = 2
                        },
                        new
                        {
                            ProductoId = new Guid("cbb29284-7653-42e2-bb40-cddb4af8bc04"),
                            Description = "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.",
                            Discount = 10,
                            Name = "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR",
                            Price = 299999m,
                            UrlImage = "https://www.fravega.com.ar/wcsstore/fravega/images/catalog/2023/Febrero/02-02-2023/82JW007LAR-01.jpg",
                            categoryId = 2
                        },
                        new
                        {
                            ProductoId = new Guid("e02fdd8a-4207-476b-bdff-0e51e02176c6"),
                            Description = "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.",
                            Discount = 5,
                            Name = "Smart TV LG 4K UHD 55' UP77",
                            Price = 799999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp",
                            categoryId = 2
                        },
                        new
                        {
                            ProductoId = new Guid("39b877d6-6826-4a2d-9184-62dc77a9f485"),
                            Description = "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.",
                            Discount = 0,
                            Name = "Zapatillas Fila deportivas con plataforma",
                            Price = 79999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp",
                            categoryId = 3
                        },
                        new
                        {
                            ProductoId = new Guid("fc8bf7ea-f922-424b-923c-56dffec78e05"),
                            Description = "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.",
                            Discount = 10,
                            Name = "Bolso de mano con diseño animal print",
                            Price = 12999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp",
                            categoryId = 3
                        },
                        new
                        {
                            ProductoId = new Guid("37badf2e-2f3d-4e34-a764-b63ce93b3112"),
                            Description = "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.",
                            Discount = 10,
                            Name = "Vestido midi con estampado floral",
                            Price = 19199m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp",
                            categoryId = 3
                        },
                        new
                        {
                            ProductoId = new Guid("0a57991d-da98-418a-8728-4380136fbf0e"),
                            Description = "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.",
                            Discount = 5,
                            Name = "Cafetera Espresso De'Longhi Dedica",
                            Price = 82999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp",
                            categoryId = 3
                        },
                        new
                        {
                            ProductoId = new Guid("bcbd2bbc-40bf-4a62-930f-a3c269a6b3b4"),
                            Description = "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.",
                            Discount = 0,
                            Name = "Juego de sábanas de algodón 100%",
                            Price = 40999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp",
                            categoryId = 4
                        },
                        new
                        {
                            ProductoId = new Guid("eeb407e8-1cc7-4498-80e6-68a868ee34b9"),
                            Description = "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.",
                            Discount = 10,
                            Name = "Sofá de dos plazas con diseño moderno",
                            Price = 1000000m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp",
                            categoryId = 4
                        },
                        new
                        {
                            ProductoId = new Guid("4a4b7071-c4a7-4ddf-b579-f87cbcda6ac7"),
                            Description = "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.",
                            Discount = 5,
                            Name = "Juego de vajilla para 6 personas",
                            Price = 34879m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp",
                            categoryId = 4
                        },
                        new
                        {
                            ProductoId = new Guid("4da52bb9-42a2-4f3c-8928-8a0d04f5f802"),
                            Description = "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.",
                            Discount = 8,
                            Name = "Set de 3 Cuadros Decorativos Modernos",
                            Price = 8999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp",
                            categoryId = 4
                        },
                        new
                        {
                            ProductoId = new Guid("02acf71c-7d89-41f5-81fb-1244e41f96f7"),
                            Description = "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.",
                            Discount = 0,
                            Name = "Crema hidratante facial con ácido hialurónico",
                            Price = 24631m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp",
                            categoryId = 5
                        },
                        new
                        {
                            ProductoId = new Guid("ccfbfecd-16a6-4e9f-bf00-b4cf910af836"),
                            Description = "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.",
                            Discount = 0,
                            Name = "Cepillo de dientes eléctrico sónico",
                            Price = 27953m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp",
                            categoryId = 5
                        },
                        new
                        {
                            ProductoId = new Guid("fad6d03a-904c-47af-a008-08e1dec882d7"),
                            Description = "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.",
                            Discount = 10,
                            Name = "Maquillaje labial de larga duración",
                            Price = 45490m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp",
                            categoryId = 5
                        },
                        new
                        {
                            ProductoId = new Guid("bdc6f74d-344b-45d7-b03e-4541f2a1e0ad"),
                            Description = "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.",
                            Discount = 0,
                            Name = "Secador de Pelo Profesional Ionic Ceramic",
                            Price = 59299m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp",
                            categoryId = 5
                        },
                        new
                        {
                            ProductoId = new Guid("80a6ddf3-6dfa-448d-bbf1-54ff6deb4c26"),
                            Description = "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.",
                            Discount = 0,
                            Name = "Pelota de fútbol",
                            Price = 29890m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp",
                            categoryId = 6
                        },
                        new
                        {
                            ProductoId = new Guid("edf4669e-ddba-4851-a6c0-fd3e32d62083"),
                            Description = "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.",
                            Discount = 5,
                            Name = "Bicicleta de montaña",
                            Price = 314689m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp",
                            categoryId = 6
                        },
                        new
                        {
                            ProductoId = new Guid("e323aa91-4ee2-4af8-9f45-2438a00ff787"),
                            Description = "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.",
                            Discount = 0,
                            Name = "Juego de mesa para toda la familia",
                            Price = 19061m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp",
                            categoryId = 6
                        },
                        new
                        {
                            ProductoId = new Guid("bb089c1b-4819-48a9-acbd-bdadf16cddb7"),
                            Description = "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!",
                            Discount = 8,
                            Name = "Tabla de Paddle Surf Hinchable Aqua Marina Fusion",
                            Price = 189999m,
                            UrlImage = "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293",
                            categoryId = 6
                        },
                        new
                        {
                            ProductoId = new Guid("343f757d-bc57-4e10-a3b9-1c31d22f2487"),
                            Description = "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.",
                            Discount = 10,
                            Name = "Bloques de construcción",
                            Price = 46509m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp",
                            categoryId = 7
                        },
                        new
                        {
                            ProductoId = new Guid("82b55041-b7de-4683-b094-f4c417297570"),
                            Description = "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.",
                            Discount = 0,
                            Name = "Muñeca",
                            Price = 27169m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp",
                            categoryId = 7
                        },
                        new
                        {
                            ProductoId = new Guid("ab47bd74-ec15-44d6-9dfc-36fad4c5e97b"),
                            Description = "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.",
                            Discount = 10,
                            Name = "Juego de mesa para niños",
                            Price = 44399m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp",
                            categoryId = 7
                        },
                        new
                        {
                            ProductoId = new Guid("f9bc7722-96ef-41d0-b762-91871d8546d2"),
                            Description = "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!",
                            Discount = 9,
                            Name = "l",
                            Price = 339999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp",
                            categoryId = 7
                        },
                        new
                        {
                            ProductoId = new Guid("4bc5aaf0-074c-46c1-88b3-2bc2a2118e52"),
                            Description = "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.",
                            Discount = 0,
                            Name = "Manzanas frescas",
                            Price = 2999m,
                            UrlImage = "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg",
                            categoryId = 8
                        },
                        new
                        {
                            ProductoId = new Guid("f5deb667-4d0f-4ac8-8b91-9d38ee616893"),
                            Description = "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.",
                            Discount = 0,
                            Name = "Leche descremada",
                            Price = 1790m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp",
                            categoryId = 8
                        },
                        new
                        {
                            ProductoId = new Guid("7ca8c055-7659-4309-a2b1-91074e05932c"),
                            Description = "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.",
                            Discount = 0,
                            Name = "Galletas de chocolate",
                            Price = 2849m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp",
                            categoryId = 8
                        },
                        new
                        {
                            ProductoId = new Guid("da1d1489-590f-4763-831a-c7bb38563ef9"),
                            Description = "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.",
                            Discount = 8,
                            Name = "Kit de Degustación de Vinos",
                            Price = 4999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp",
                            categoryId = 8
                        },
                        new
                        {
                            ProductoId = new Guid("00d96e24-6072-4609-8944-ef7d71c43799"),
                            Description = "Este libro de ficción es una novela apasionante que te atrapará desde el principio.",
                            Discount = 0,
                            Name = "Libro de ficción",
                            Price = 22900m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp",
                            categoryId = 9
                        },
                        new
                        {
                            ProductoId = new Guid("1a06e3f7-a838-4e9c-bc7b-67017b671f7b"),
                            Description = "Estos lápices de colores son ideales para que los niños exploren su creatividad.",
                            Discount = 0,
                            Name = "Lápices de colores",
                            Price = 19999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp",
                            categoryId = 9
                        },
                        new
                        {
                            ProductoId = new Guid("6ab3185d-3541-461f-849c-23b306788e39"),
                            Description = "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.",
                            Discount = 0,
                            Name = "Cuaderno de notas",
                            Price = 11990m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp",
                            categoryId = 9
                        },
                        new
                        {
                            ProductoId = new Guid("a37a7be1-5fe4-4e95-bd0f-bef9711194ea"),
                            Description = "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.",
                            Discount = 8,
                            Name = "Libro de Cocina: Recetas del Mundo",
                            Price = 1999m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp",
                            categoryId = 9
                        },
                        new
                        {
                            ProductoId = new Guid("8fd25588-9fda-466c-8510-432b6f32fb10"),
                            Description = "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.",
                            Discount = 10,
                            Name = "Tijeras de podar",
                            Price = 64368m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp",
                            categoryId = 10
                        },
                        new
                        {
                            ProductoId = new Guid("afac0a93-d08d-4a5e-ae46-2ec16ec69e6c"),
                            Description = "Esta manguera de jardín es perfecta para regar tus plantas y flores.",
                            Discount = 10,
                            Name = "Manguera de jardín",
                            Price = 41582m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp",
                            categoryId = 10
                        },
                        new
                        {
                            ProductoId = new Guid("4e0e6517-9a98-49a3-8399-18a6a83577af"),
                            Description = "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.",
                            Discount = 10,
                            Name = "Kit de herramientas básicas",
                            Price = 65499m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp",
                            categoryId = 10
                        },
                        new
                        {
                            ProductoId = new Guid("f727bcaf-b030-4704-97f9-1d80b1e786fb"),
                            Description = "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.",
                            Discount = 9,
                            Name = "Kit de Herramientas de Jardinería",
                            Price = 2299m,
                            UrlImage = "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp",
                            categoryId = 10
                        });
                });

            modelBuilder.Entity("Domain.Entitys.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleId");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("Domain.Entitys.SaleProduct", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartId"));

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleProducts", (string)null);
                });

            modelBuilder.Entity("Domain.Entitys.Product", b =>
                {
                    b.HasOne("Domain.Entitys.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entitys.SaleProduct", b =>
                {
                    b.HasOne("Domain.Entitys.Product", "Products")
                        .WithMany("SaleProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entitys.Sale", "Sales")
                        .WithMany("SaleProducts")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Domain.Entitys.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entitys.Product", b =>
                {
                    b.Navigation("SaleProducts");
                });

            modelBuilder.Entity("Domain.Entitys.Sale", b =>
                {
                    b.Navigation("SaleProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
