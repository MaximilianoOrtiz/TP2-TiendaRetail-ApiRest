using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.DataSet
{
    public class ProductsDummy : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
               //Electrodomesticos
               new Product(
                   Guid.NewGuid(),
                   "Lavarropas Carga Frontal Drean Next 6 Kg",
                   "Lavarropas con capacidad de 12 Kg, 14 programas de lavado, eficiencia energética A, centrifugado de 750 rpm, función antiarrugas, dispensador automático de detergente, puerta con visor de vidrio templado y panel de control electrónico.",
                   679999,
                   0,
                   "https://images.fravega.com/f300/bc553a4d53bb5eb5f9e44184047b212b.jpg.webp",
                   1
                   ),
               new Product(
                   Guid.NewGuid(),
                   "Heladera Cíclica GAFA HGF358AFB 282Lts Blanca",
                   "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.",
                   629999,
                   11,
                   "https://images.fravega.com/f300/a55db6e62b330fc4768c2bfa9370a5b0.jpg.webp",
                   1
                   ),
               new Product(
                   Guid.NewGuid(),
                   "Aire Acondicionado Split Surrey Inverter Frio/Calor 3000 F",
                   "Aire acondicionado con capacidad de frío de 3000 frigorías y capacidad de calor de 3000 watts. Tecnología Inverter, eficiencia energética A, función de deshumidificación, timer programable, control remoto y modo Sleep.",
                   1489999,
                   5,
                   "https://www.fravega.com/p/aire-acondicionado-split-frio-calor-surrey-3000f-3490w-553bfq1201e--20459/",
                   1
                   ),
               new Product(
                    Guid.NewGuid(),
                    "Lavarropa Samsung Ww10t504daw 10kg Blanco Con Ia Inverter",
                    "Lavadora de carga frontal con capacidad de lavado de 10.5 kg. Tecnología EcoBubble que activa el detergente con aire y agua antes de que comience el ciclo de lavado, garantizando una limpieza profunda incluso en agua fría. Eficiencia energética A+++, múltiples programas de lavado, pantalla LED táctil, y sistema de auto-limpieza.",
                    2000999,
                    4,
                    "https://http2.mlstatic.com/D_NQ_NP_910743-MLA73490348656_122023-O.webp",
                    1
                    ),

               //Tecnología y Electrónica
               new Product(
                   Guid.NewGuid(),
                   "Televisor Smart TV LED 50\" 4K UHD LG 50UQ9300PTA",
                   "Televisor Smart TV LED LG de 50 pulgadas con resolución 4K UHD. Cuenta con tecnología LED para un brillo y contraste excepcionales, y su procesador inteligente te garantiza imágenes nítidas y colores vibrantes. Además, su plataforma Smart TV te permite acceder a tus aplicaciones favoritas de streaming con facilidad.",
                   573999,
                   0,
                   "https://images.fravega.com/f300/9f3103a4c80350aadc0f1f228cbab083.jpg.webp",
                   2
                   ),
               new Product(
                   Guid.NewGuid(),
                   "Celular Samsung Galaxy S23 Ultra 5G 256GB",
                   "El celular Samsung Galaxy S23 Ultra 5G es el teléfono inteligente definitivo para los amantes de la tecnología. Con una pantalla AMOLED de 6.8 pulgadas y un potente procesador Snapdragon 8 Gen 1, este teléfono te ofrece un rendimiento ultrarrápido y una experiencia visual inmersiva. Además, su sistema de cámara cuádruple trasera de 108 MP te permite capturar fotos y videos impresionantes.",
                   249999,
                   0,
                   "https://images.fravega.com/f300/68684fb77ad8b2609023cefea3c6c094.jpg.webp",
                   2),
               new Product(
                   Guid.NewGuid(),
                   "Notebook Gamer Lenovo Legion 5 15ACH6H 82JW007LAR",
                   "Disfruta de tus juegos favoritos con el notebook gamer Lenovo Legion 5. Este potente equipo cuenta con un procesador AMD Ryzen 7 6800H, una placa de video NVIDIA GeForce RTX 3050 Ti y 16 GB de RAM, lo que te garantiza un rendimiento fluido y sin interrupciones. Además, su pantalla Full HD de 15.6 pulgadas con una tasa de refresco de 165 Hz te brinda imágenes nítidas y una experiencia de juego inmersiva.",
                   299999,
                   10,
                   "https://www.fravega.com.ar/wcsstore/fravega/images/catalog/2023/Febrero/02-02-2023/82JW007LAR-01.jpg",
                   2
                   ),
               new Product(
                    Guid.NewGuid(),
                    "Smart TV LG 4K UHD 55' UP77",
                    "Disfruta de imágenes nítidas y colores vibrantes con el Smart TV LG 4K UHD 55' UP77. Con una pantalla de 55 pulgadas, resolución 4K UHD, y tecnología de mejora de imagen AI Picture, ofrece una experiencia visual envolvente. Además, cuenta con webOS, control por voz, y múltiples opciones de conectividad para acceder a tus contenidos favoritos.",
                    799999,
                    5,
                    "https://http2.mlstatic.com/D_NQ_NP_672706-MLU75135396807_032024-O.webp",
                    2
                ),

                // Moda y Accesorios:
                new Product(
                   Guid.NewGuid(),
                   "Zapatillas Fila deportivas con plataforma",
                   "Estas zapatillas deportivas con plataforma son perfectas para un look casual y cómodo. Su diseño moderno y trendy te hará destacar entre la multitud. La plataforma te dará un poco de altura extra y la suela acolchada te brindará comodidad durante todo el día.",
                   79999,
                   0,
                   "https://http2.mlstatic.com/D_NQ_NP_809755-MLA74807971075_022024-O.webp",
                   3
                   ),
                new Product(
                   Guid.NewGuid(),
                   "Bolso de mano con diseño animal print",
                   "Este bolso de mano con diseño animal print es el accesorio perfecto para cualquier outfit. Su diseño elegante y sofisticado te hará sentir segura y glamorosa. El tamaño perfecto para llevar todo lo que necesitas.",
                   12999,
                   10,
                   "https://http2.mlstatic.com/D_NQ_NP_2X_908309-MLA43823200371_102020-F.webp",
                   3
                   ),
                new Product(
                   Guid.NewGuid(),
                   "Vestido midi con estampado floral",
                   "Este vestido midi con estampado floral es perfecto para cualquier ocasión. Su diseño elegante y femenino te hará sentir segura y hermosa. El tejido suave y fluido te mantendrá cómoda durante todo el día.",
                   19199,
                   10,
                   "https://http2.mlstatic.com/D_NQ_NP_2X_827000-MLA73259012235_122023-F.webp",
                   3
                   ),
                new Product(
                    Guid.NewGuid(),
                    "Cafetera Espresso De'Longhi Dedica",
                    "Cafetera Espresso De'Longhi Dedica con bomba de presión de 15 bares. Diseño compacto y elegante. Opciones de preparación personalizadas. Disfruta de café de alta calidad en casa.",
                    82999,
                    5,
                    "https://http2.mlstatic.com/D_NQ_NP_924147-MLA32583951215_102019-O.webp",
                    3
                    ),

                //Hogar y Decoración
                new Product(
                   Guid.NewGuid(),
                   "Juego de sábanas de algodón 100%",
                   "Este juego de sábanas de algodón 100% te brindará una experiencia de sueño confortable y placentera. El algodón es un material suave y transpirable que te mantendrá fresco en verano y cálido en invierno.",
                   40999,
                   0,
                   "https://http2.mlstatic.com/D_NQ_NP_992437-MLU73437277182_122023-O.webp",
                   4
                   ),
                new Product(
                   Guid.NewGuid(),
                   "Sofá de dos plazas con diseño moderno",
                   "Este sofá de dos plazas con diseño moderno es perfecto para cualquier living. Su diseño elegante y minimalista le dará un toque de sofisticación a tu hogar. El tapizado de tela es suave y resistente.",
                   1000000,
                   10,
                   "https://http2.mlstatic.com/D_NQ_NP_953815-MLA46281130948_062021-O.webp",
                   4
                   ),
                new Product(
                   Guid.NewGuid(),
                   "Juego de vajilla para 6 personas",
                   "Este juego de vajilla para 6 personas es perfecto para cualquier ocasión. Su diseño clásico y elegante le dará un toque de distinción a tu mesa. El material de porcelana es resistente y duradero.",
                   34879,
                   5,
                   "https://http2.mlstatic.com/D_NQ_NP_2X_915185-MLA75190486128_032024-F.webp",
                   4
                   ),
                new Product(
                    Guid.NewGuid(),
                    "Set de 3 Cuadros Decorativos Modernos",
                    "Set de 3 cuadros decorativos modernos con diseños abstractos. Fabricados con materiales de alta calidad. Ideal para renovar tu espacio con estilo.",
                    8999,
                    8,
                    "https://http2.mlstatic.com/D_NQ_NP_891360-MLA50450337942_062022-O.webp",
                    4
                    ),

                //Salud y Belleza
                new Product(
                   Guid.NewGuid(),
                   "Crema hidratante facial con ácido hialurónico",
                   "Esta crema hidratante facial con ácido hialurónico es perfecta para todo tipo de piel. El ácido hialurónico es un ingrediente que ayuda a retener la hidratación en la piel, lo que la hace lucir más joven y radiante.",
                   24631,
                   0,
                   "https://http2.mlstatic.com/D_NQ_NP_651558-MLA52220013087_102022-O.webp",
                   5
                   ),
                new Product(
                   Guid.NewGuid(),
                   "Cepillo de dientes eléctrico sónico",
                   "Este cepillo de dientes eléctrico sónico te ayudará a tener una limpieza bucal más profunda y efectiva. Las cerdas sónicas vibran a alta velocidad para eliminar la placa y el sarro de forma eficaz.",
                   27953,
                   0,
                   "https://http2.mlstatic.com/D_NQ_NP_2X_640938-MLA74353765176_022024-F.webp",
                   5
                   ),
                new Product(
                   Guid.NewGuid(),
                   "Maquillaje labial de larga duración",
                   "Este labial de larga duración te brindará un color intenso y duradero. Su fórmula especial es resistente al agua y a los besos.",
                   45490,
                   10,
                   "https://http2.mlstatic.com/D_NQ_NP_2X_990774-MLU75051228244_032024-F.webp",
                    5
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Secador de Pelo Profesional Ionic Ceramic",
                    "Secador de pelo profesional con tecnología Ionic Ceramic para un secado rápido y sin frizz. Potente motor de 2200W con 3 ajustes de temperatura y 2 velocidades. Incluye boquilla concentradora y difusor para estilizar el cabello según tus preferencias. Consigue un cabello suave, brillante y saludable con este secador de pelo de calidad profesional.",
                    59299,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_797457-MLA49192142777_022022-O.webp",
                    5
                ),

               //Deportes y Ocio
               new Product(
                    Guid.NewGuid(),
                    "Pelota de fútbol",
                    "Esta pelota de fútbol es perfecta para jugar con amigos o en familia. Su diseño clásico y su material resistente te brindarán horas de diversión.",
                    29890,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_814346-MLU72542363030_112023-O.webp",
                    6
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Bicicleta de montaña",
                    "Esta bicicleta de montaña es perfecta para los amantes del ciclismo. Su diseño resistente y duradero te permitirá disfrutar de tus aventuras al aire libre.",
                    314689,
                    5,
                    "https://http2.mlstatic.com/D_NQ_NP_692292-MLA48659462745_122021-O.webp",
                    6
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Juego de mesa para toda la familia",
                    "Este juego de mesa es perfecto para pasar un rato divertido en familia. Su diseño atractivo y sus reglas sencillas te brindarán horas de entretenimiento.",
                    19061,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_2X_742516-MLA44728186422_012021-F.webp",
                    6
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Tabla de Paddle Surf Hinchable Aqua Marina Fusion",
                    "Disfruta del agua con la tabla de paddle surf hinchable Aqua Marina Fusion. Fabricada con material de alta calidad, esta tabla ofrece estabilidad y durabilidad. Su diseño hinchable la hace fácil de transportar y almacenar. Equipada con una bomba de alta presión y una bolsa de transporte, es perfecta para explorar lagos, ríos y costas. ¡Sumérgete en la diversión con esta tabla de paddle surf!",
                    189999,
                    8,
                    "https://cdn.shopify.com/s/files/1/0233/3953/2624/products/14-FUSION-01-2020-IMG_1737-2_1000x.jpg?v=1609160293",
                    6
                    ),

                //Juguetes y Juegos
                new Product(
                    Guid.NewGuid(),
                    "Bloques de construcción",
                    "Estos bloques de construcción son perfectos para que los niños desarrollen su creatividad e imaginación. Con ellos podrán construir todo tipo de estructuras, desde casas y castillos hasta naves espaciales y robots.",
                    46509,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_653633-MLU72122811116_102023-O.webp",
                    7
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Muñeca",
                    "Esta muñeca es perfecta para que las niñas se diviertan y aprendan a cuidar de los demás. Viene con ropa y accesorios para que las niñas puedan crear todo tipo de historias.",
                    27169,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_891562-MLU74194879919_012024-O.webp",
                    7
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Juego de mesa para niños",
                    "Este juego de mesa es perfecto para que los niños se diviertan en familia. Sus reglas sencillas y su diseño atractivo lo hacen ideal para niños de todas las edades.",
                    44399,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_874287-MLU72637351761_112023-O.webp",
                    7
                    ),
                new Product(
                    Guid.NewGuid(),
                    "l",
                    "Construye una de las maravillas del mundo con el set LEGO Creator Expert Taj Mahal. Este impresionante set incluye más de 9500 piezas para recrear fielmente este icónico monumento. Con detalles intrincados y una escala impresionante, esta maqueta proporciona una experiencia de construcción desafiante y gratificante para aficionados y coleccionistas. ¡Embárcate en un viaje arquitectónico con este magnífico set de LEGO!",
                    339999,
                    9,
                    "https://http2.mlstatic.com/D_NQ_NP_794783-MLA54926679565_042023-O.webp",
                    7
                    ),

                //Alimentos y Bebidas
                new Product(
                    Guid.NewGuid(),
                    "Manzanas frescas",
                    "Estas manzanas frescas son de la mejor calidad y tienen un sabor delicioso. Son perfectas para comer como snack o para usar en recetas.",
                    2999,
                    0,
                    "https://img.freepik.com/foto-gratis/manzanas-rojas-frescas-suaves-jugosas-enteras-perfectas-escritorio-blanco_179666-271.jpg",
                    8
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Leche descremada",
                    "Esta leche descremada es ideal para aquellos que buscan una opción más saludable. Es baja en calorías y grasa, pero aún así tiene un sabor delicioso.",
                    1790,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_2X_794418-MLU73783720994_012024-F.webp",
                    8
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Galletas de chocolate",
                    "Estas galletas de chocolate son perfectas para disfrutar con un café o un té. Son deliciosas y crujientes.",
                    2849,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_770512-MLA52795200078_122022-O.webp",
                    8
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Kit de Degustación de Vinos",
                    "Explora el mundo del vino con este kit de degustación que incluye una selección de vinos de diferentes variedades y regiones. Cada botella está cuidadosamente seleccionada para ofrecer una experiencia única de degustación. Descubre nuevos sabores, aromas y texturas mientras disfrutas de una velada especial con amigos o familiares.",
                    4999,
                    8,
                    "https://http2.mlstatic.com/D_NQ_NP_2X_778460-MLA74696522802_022024-F.webp",
                    8
                ),


                // Libros y Material Educativo
                new Product(
                    Guid.NewGuid(),
                    "Libro de ficción",
                    "Este libro de ficción es una novela apasionante que te atrapará desde el principio.",
                    22900,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_790538-MLU73106969282_122023-O.webp",
                    9
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Lápices de colores",
                    "Estos lápices de colores son ideales para que los niños exploren su creatividad.",
                    19999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_625215-MLU73129288734_122023-O.webp",
                    9
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Cuaderno de notas",
                    "Este cuaderno de notas es perfecto para tomar apuntes en clase o en la oficina.",
                    11990,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_969804-MLU72605081373_102023-O.webp",
                    9
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Libro de Cocina: Recetas del Mundo",
                    "Descubre una variedad de deliciosas recetas de diferentes culturas y regiones del mundo con este libro de cocina. Desde platos tradicionales hasta opciones modernas, este libro te guiará a través de pasos sencillos para crear comidas increíbles en tu propia cocina. Con fotografías inspiradoras y consejos útiles, es perfecto para chefs aficionados y entusiastas de la cocina.",
                    1999,
                    8,
                    "https://http2.mlstatic.com/D_NQ_NP_622837-MLU74371917389_022024-O.webp",
                    9
                ),


                //Jardinería y Bricolaje
                new Product(
                    Guid.NewGuid(),
                    "Tijeras de podar",
                    "Estas tijeras de podar son ideales para cortar ramas y tallos de plantas.",
                    64368,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_997006-MLU73673556155_122023-O.webp",
                    10
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Manguera de jardín",
                    "Esta manguera de jardín es perfecta para regar tus plantas y flores.",
                    41582,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_924765-MLU75436466640_042024-O.webp",
                    10
                    ),
                new Product(
                    Guid.NewGuid(),
                    "Kit de herramientas básicas",
                    "Este kit de herramientas básicas es perfecto para realizar pequeños trabajos de bricolaje en casa.",
                    65499,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_649163-MLU75509398453_032024-O.webp",
                    10
                ),
                new Product(
                    Guid.NewGuid(),
                    "Kit de Herramientas de Jardinería",
                    "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.",
                    2299,
                    9,
                    "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp",
                    10
                )
            );
        }
    }
}
