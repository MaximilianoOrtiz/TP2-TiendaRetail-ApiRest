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

               new Product(
                    Guid.NewGuid(),
                    "Microondas Whirlpool MW 25 BA 25L",
                    "Microondas con capacidad de 25 litros, potencia de 800W, función de cocina rápida, pantalla LED y botones de control electrónicos.",
                    449999,
                    2,
                    "https://http2.mlstatic.com/D_NQ_NP_798058-MLU74033812160_012024-O.webp",
                    1
                ),
                new Product(
                    Guid.NewGuid(),
                    "Lavarropas LG F-1402H5B 12Kg Inverter",
                    "Lavarropas con capacidad de 12 kg, tecnología Inverter, eficiencia energética A++, 14 programas de lavado, función de vapor para eliminar arrugas, y pantalla LED táctil.",
                    899999,
                    3,
                    "https://http2.mlstatic.com/D_NQ_NP_742423-MLA51835012835_102022-O.webp",
                    1
                ),
                new Product(
                    Guid.NewGuid(),
                    "Heladera Side by Side Samsung RS50N3513SL/AA 505Lts",
                    "Heladera con capacidad total de 505 litros, 342 litros de heladera y 163 litros de freezer. Sistema de frío No Frost, eficiencia energética A++, 4 estrellas de freezer, función de congelamiento rápido, y dispenser de agua y hielo.",
                    2499999,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_972873-MLA50008739804_052022-O.webp",
                    1
                ),
                new Product(
                    Guid.NewGuid(),
                    "Aire Acondicionado Split LG F-Q186KXA 18000 F",
                    "Aire acondicionado con capacidad de frío de 18000 frigorías y capacidad de calor de 18000 watts. Tecnología Inverter, eficiencia energética A++, función de deshumidificación, timer programable, control remoto y modo Sleep.",
                    1999999,
                    6,
                    "https://http2.mlstatic.com/D_NQ_NP_629906-MLA74780228753_022024-O.webp",
                    1
                ),
                new Product(
                    Guid.NewGuid(),
                    "Lavarropas Drean Next 8 Kg Inverter",
                    "Lavarropas con capacidad de 8 kg, tecnología Inverter, eficiencia energética A++, 14 programas de lavado, función de vapor para eliminar arrugas, y pantalla LED táctil.",
                    749999,
                    1,
                    "https://http2.mlstatic.com/D_NQ_NP_816984-MLA53496425042_012023-O.webp",
                    1
                ),
                new Product(
                    Guid.NewGuid(),
                    "Heladera Cíclica GAFA HGF358AFB 282Lts Inoxidable",
                    "Heladera con capacidad total de 311 litros, 224 litros de heladera y 87 litros de freezer. Sistema de frío No Frost, eficiencia energética A, 4 estrellas de freezer, función de congelamiento rápido, dispenser de agua y luz LED interior.",
                    699999,
                    12,
                    "https://http2.mlstatic.com/D_NQ_NP_986989-MLU74218962327_012024-O.webp",
                    1
                ),
                new Product(
                    Guid.NewGuid(),
                    "Microondas Panasonic NN-ST665B 27L",
                    "Microondas con capacidad de 27 litros, potencia de 1000W, función de cocina rápida, pantalla LED y botones de control electrónicos.",
                    549999,
                    2,
                    "https://http2.mlstatic.com/D_NQ_NP_858971-MLA74978511181_032024-O.webp",
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
                   "https://http2.mlstatic.com/D_NQ_NP_871625-MLA75823629201_042024-O.webp",
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

               new Product(
                    Guid.NewGuid(),
                    "Tablet Apple iPad Pro 12.9\" 128GB Wi-Fi",
                    "La nueva iPad Pro de 12.9 pulgadas de Apple ofrece una potencia sin igual gracias a su chip M1. Con 128GB de almacenamiento y una pantalla Liquid Retina XDR, es perfecta para tareas creativas y de productividad. Además, cuenta con un sistema de cámaras avanzadas y compatibilidad con el Apple Pencil y el Magic Keyboard.",
                    1029999,
                    3,
                    "https://http2.mlstatic.com/D_NQ_NP_814559-MLA53970921150_022023-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Smartwatch Apple Watch Series 7 GPS 45mm",
                    "El Apple Watch Series 7 cuenta con una pantalla más grande y avanzada, resistencia al polvo y al agua, y un cargado rápido. Además, incluye funcionalidades de salud y fitness como monitoreo de oxígeno en sangre, ECG y una amplia variedad de aplicaciones deportivas.",
                    529999,
                    7,
                    "https://http2.mlstatic.com/D_NQ_NP_858093-MLA48096508611_112021-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Auriculares Inalámbricos Sony WH-1000XM4",
                    "Los auriculares Sony WH-1000XM4 ofrecen una cancelación de ruido líder en la industria, un sonido excepcional y comodidad durante todo el día. Con una batería de larga duración y características inteligentes como el control táctil y el Speak-to-Chat, son ideales para disfrutar de tu música sin interrupciones.",
                    149999,
                    12,
                    "https://http2.mlstatic.com/D_NQ_NP_918604-MLA44483909501_012021-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Consola PlayStation 5",
                    "La consola PlayStation 5 de Sony ofrece una experiencia de juego de próxima generación con gráficos impresionantes, tiempos de carga ultrarrápidos y una nueva generación de juegos exclusivos. Su controlador DualSense proporciona una inmersión sin precedentes gracias a su respuesta háptica y gatillos adaptativos.",
                    1199999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_802856-MLU76753493373_052024-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Parlante Bluetooth JBL Charge 5",
                    "El JBL Charge 5 es un parlante Bluetooth portátil que ofrece un sonido potente y claro. Con una batería de hasta 20 horas de duración, resistencia al agua y polvo (IP67) y la capacidad de cargar tus dispositivos móviles, es perfecto para llevar tu música a cualquier lugar.",
                    69999,
                    15,
                    "https://http2.mlstatic.com/D_NQ_NP_778458-MLU72636564641_112023-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Monitor Samsung Curvo 27\" Full HD LC27R500FHNXZA",
                    "El monitor curvo de Samsung de 27 pulgadas te ofrece una experiencia inmersiva con su pantalla Full HD y una curvatura 1800R. Con tecnología AMD FreeSync y una frecuencia de actualización de 75 Hz, es ideal para juegos y entretenimiento.",
                    109999,
                    8,
                    "https://http2.mlstatic.com/D_NQ_NP_904906-MLU69761863493_062023-O.webp",
                    2
                ),

                new Product(
                    Guid.NewGuid(),
                    "Cámara Canon EOS Rebel T7",
                    "La cámara Canon EOS Rebel T7 es perfecta para fotógrafos principiantes. Cuenta con un sensor CMOS de 24.1 MP, pantalla LCD de 3 pulgadas y conectividad Wi-Fi para compartir tus fotos al instante. Además, incluye una lente 18-55mm.",
                    189999,
                    5,
                    "",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Laptop Apple MacBook Pro 14\" M1 Pro",
                    "El MacBook Pro de 14 pulgadas con chip M1 Pro de Apple ofrece un rendimiento y eficiencia excepcionales. Con una pantalla Liquid Retina XDR, hasta 32GB de RAM y 1TB de almacenamiento SSD, es ideal para profesionales creativos.",
                    2399999,
                    3,
                    "",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Drone DJI Mavic Air 2",
                    "El DJI Mavic Air 2 es un drone avanzado con una cámara 4K de 48MP, tiempo de vuelo de hasta 34 minutos y múltiples modos de vuelo inteligentes. Perfecto para capturar fotos y videos aéreos de alta calidad.",
                    699999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_727004-MLA75232255242_032024-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Barra de Sonido Bose Smart Soundbar 700",
                    "La Bose Smart Soundbar 700 ofrece un sonido inmersivo y conectividad inteligente con Alexa y Google Assistant integrados. Su diseño elegante y su rendimiento acústico superior mejoran cualquier sistema de entretenimiento en el hogar.",
                    399999,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_843862-MLA42478366506_072020-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Impresora Multifuncional HP OfficeJet Pro 9015e",
                    "La HP OfficeJet Pro 9015e es una impresora multifuncional ideal para oficinas pequeñas y medianas. Ofrece impresión a doble cara, escaneo, copia y fax con alta velocidad y calidad profesional.",
                    229999,
                    7,
                    "https://http2.mlstatic.com/D_NQ_NP_768300-MLA41233060022_032020-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Router WiFi 6 ASUS RT-AX86U",
                    "El router ASUS RT-AX86U es ideal para juegos y transmisión en 4K. Ofrece tecnología WiFi 6 con velocidades de hasta 5700 Mbps, puerto gaming de 2.5 Gbps y seguridad AiProtection Pro.",
                    199999,
                    12,
                    "https://http2.mlstatic.com/D_NQ_NP_760437-MLU76150445423_052024-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Proyector Epson Home Cinema 2150",
                    "El proyector Epson Home Cinema 2150 ofrece una experiencia de cine en casa con resolución Full HD 1080p, 2500 lúmenes de brillo y conectividad inalámbrica. Perfecto para ver películas y jugar videojuegos en gran pantalla.",
                    299999,
                    6,
                    "https://http2.mlstatic.com/D_NQ_NP_650108-MLA74903080735_032024-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Bocina Inteligente Amazon Echo Dot 4ta Generación",
                    "El Amazon Echo Dot de 4ta generación con reloj ofrece control por voz con Alexa, sonido mejorado y un diseño elegante. Ideal para gestionar dispositivos inteligentes, reproducir música y obtener información instantánea.",
                    49999,
                    15,
                    "https://http2.mlstatic.com/D_NQ_NP_907304-MLA76219497482_052024-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Cámara de Seguridad Ring Stick Up Cam Battery",
                    "La Ring Stick Up Cam Battery es una cámara de seguridad versátil para interiores y exteriores. Ofrece video HD 1080p, detección de movimiento, visión nocturna y comunicación bidireccional. Funciona con batería recargable o alimentación solar.",
                    89999,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_968604-MLA73899541113_012024-O.webp",
                    2
                ),
                new Product(
                    Guid.NewGuid(),
                    "Audífonos Bluetooth Bose QuietComfort Earbuds",
                    "Los Bose QuietComfort Earbuds ofrecen cancelación de ruido avanzada, sonido de alta calidad y un ajuste cómodo y seguro. Son ideales para disfrutar de tu música sin interrupciones, con una batería de hasta 6 horas de duración.",
                    199999,
                    8,
                    "https://http2.mlstatic.com/D_NQ_NP_609529-MLU74226371875_012024-O.webp",
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


                new Product(
                    Guid.NewGuid(),
                    "Gafas de sol Ray-Ban Aviator",
                    "Las gafas de sol Ray-Ban Aviator son un clásico atemporal. Con su diseño elegante y lentes polarizados, ofrecen protección UV y estilo. Perfectas para cualquier ocasión.",
                    19999,
                    20,
                    "https://http2.mlstatic.com/D_NQ_NP_876333-MLA74134571216_012024-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Reloj inteligente Apple Watch Series 6",
                    "El Apple Watch Series 6 es un accesorio moderno y funcional. Con monitoreo de salud, GPS, y múltiples aplicaciones, es perfecto para mantenerte conectado y saludable.",
                    499999,
                    15,
                    "https://http2.mlstatic.com/D_NQ_NP_792553-MLU73159525351_112023-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Mochila Jansport clásica",
                    "La mochila Jansport clásica es ideal para la escuela o el trabajo. Con amplio espacio de almacenamiento y diseño resistente, ofrece comodidad y durabilidad.",
                    59999,
                    8,
                    "https://http2.mlstatic.com/D_NQ_NP_967659-MLU70516232392_072023-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Cartera de cuero Michael Kors",
                    "La cartera de cuero Michael Kors es un accesorio elegante y práctico. Con múltiples compartimentos y un diseño sofisticado, es perfecta para llevar tus esenciales con estilo.",
                    159999,
                    12,
                    "https://http2.mlstatic.com/D_NQ_NP_990693-MLA74704426792_022024-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Sombrero Fedora de lana",
                    "El sombrero Fedora de lana es un accesorio clásico y elegante. Perfecto para añadir un toque de estilo a cualquier atuendo, este sombrero es ideal para el otoño e invierno.",
                    29999,
                    5,
                    "https://http2.mlstatic.com/D_NQ_NP_671496-MLA45427114933_042021-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Chaqueta de cuero negra",
                    "La chaqueta de cuero negra es un básico de moda imprescindible. Con su diseño atemporal y ajuste perfecto, es ideal para cualquier ocasión y combina con todo.",
                    249999,
                    7,
                    "https://http2.mlstatic.com/D_NQ_NP_829598-MLA75171128806_032024-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Pantalones de mezclilla Levi's 501",
                    "Los pantalones de mezclilla Levi's 501 son un clásico que nunca pasa de moda. Con su corte recto y ajuste cómodo, son ideales para un look casual y versátil.",
                    99999,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_925069-MLA49693821162_042022-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Blusa de seda con lazo",
                    "Esta blusa de seda con lazo es perfecta para un look elegante y femenino. Su diseño delicado y tejido suave te harán sentir cómoda y chic en cualquier ocasión.",
                    74999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_668789-MLA73659925632_012024-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Cinturón de cuero Calvin Klein",
                    "El cinturón de cuero Calvin Klein es un accesorio sofisticado y versátil. Con su diseño minimalista y elegante, es perfecto para completar cualquier atuendo.",
                    34999,
                    20,
                    "https://http2.mlstatic.com/D_NQ_NP_913222-MLA77275857767_062024-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Zapatillas deportivas Nike Air Max",
                    "Las zapatillas deportivas Nike Air Max combinan estilo y comodidad. Con su diseño icónico y tecnología de amortiguación, son perfectas para el uso diario y actividades deportivas.",
                    129999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_912442-MLA77092906427_062024-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Bufanda de lana merino",
                    "La bufanda de lana merino es un accesorio esencial para el invierno. Suave y cálida, es perfecta para mantenerte abrigado con estilo durante los días fríos.",
                    19999,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_744846-MLA76662301416_062024-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Bolso tote de tela",
                    "El bolso tote de tela es práctico y estiloso. Con amplio espacio de almacenamiento y un diseño moderno, es perfecto para llevar tus esenciales diarios.",
                    44999,
                    15,
                    "https://http2.mlstatic.com/D_NQ_NP_949148-MLU75692429655_042024-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Falda plisada midi",
                    "Esta falda plisada midi es elegante y versátil. Con su diseño femenino y tejido ligero, es perfecta para cualquier ocasión, desde el trabajo hasta eventos especiales.",
                    59999,
                    8,
                    "https://http2.mlstatic.com/D_NQ_NP_713957-MLA70114688153_062023-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Botines de cuero marrón",
                    "Los botines de cuero marrón son un calzado clásico y atemporal. Con su diseño robusto y elegante, son perfectos para el uso diario y combinan con cualquier atuendo.",
                    149999,
                    5,
                    "https://http2.mlstatic.com/D_NQ_NP_777105-MLA70924305746_082023-O.webp",
                    3
                ),
                new Product(
                    Guid.NewGuid(),
                    "Gorro de lana tejido",
                    "El gorro de lana tejido es un accesorio esencial para el invierno. Suave y cálido, es perfecto para mantener tu cabeza abrigada y añadir un toque de estilo a tu look.",
                    9999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_766012-MLA54959307419_042023-O.webp",
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


                new Product(
                    Guid.NewGuid(),
                    "Alfombra de área grande",
                    "Esta alfombra de área grande es perfecta para darle un toque de calidez y estilo a tu hogar. Su diseño moderno y colores vibrantes complementarán cualquier decoración.",
                    59999,
                    3,
                    "https://http2.mlstatic.com/D_NQ_NP_678277-MLA50585725957_072022-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Lámpara de mesa de diseño",
                    "Esta lámpara de mesa de diseño es ideal para iluminar tu espacio con estilo. Su base elegante y pantalla de tela proporcionan una luz suave y agradable.",
                    24999,
                    10,
                    "https://http2.mlstatic.com/D_NQ_NP_747581-MLA73179961416_122023-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Cortinas blackout de lino",
                    "Las cortinas blackout de lino son perfectas para mantener la privacidad y bloquear la luz no deseada. Su tejido de alta calidad y diseño elegante mejorarán cualquier habitación.",
                    32999,
                    5,
                    "https://http2.mlstatic.com/D_NQ_NP_888846-MLA69964681489_062023-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Estantería modular de madera",
                    "Esta estantería modular de madera es una solución de almacenamiento versátil y estilosa. Su diseño modular te permite personalizarla según tus necesidades.",
                    45999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_683332-MLU74725847452_032024-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Juego de toallas de algodón egipcio",
                    "Este juego de toallas de algodón egipcio es lujoso y absorbente. Perfecto para añadir un toque de elegancia a tu baño. El set incluye toallas de baño, de mano y toallas faciales.",
                    29999,
                    12,
                    "https://http2.mlstatic.com/D_NQ_NP_935868-MLA76111646337_042024-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Planta artificial decorativa",
                    "La planta artificial decorativa es perfecta para agregar un toque de verde a tu hogar sin necesidad de mantenimiento. Su diseño realista complementará cualquier decoración.",
                    15999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_611532-MLA72597798496_112023-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Espejo de pared grande",
                    "El espejo de pared grande es un accesorio esencial para cualquier hogar. Su diseño elegante y marco robusto lo convierten en una pieza decorativa y funcional.",
                    78999,
                    5,
                    "https://http2.mlstatic.com/D_NQ_NP_983208-MLU75985619618_052024-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Mesa de centro de madera y metal",
                    "Esta mesa de centro de madera y metal combina estilo industrial y funcionalidad. Es perfecta para complementar la decoración de tu sala de estar.",
                    89999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_867489-MLA74928886215_032024-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Colcha de cama King size",
                    "La colcha de cama King size es ideal para agregar un toque de lujo a tu dormitorio. Su diseño elegante y material suave te proporcionarán confort y estilo.",
                    54999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_934128-MLA48538774826_122021-O.webp",
                    4
                ),
                new Product(
                    Guid.NewGuid(),
                    "Juego de candelabros de metal",
                    "Este juego de candelabros de metal es perfecto para crear una atmósfera acogedora en tu hogar. Su diseño elegante y acabado en oro añaden un toque de sofisticación.",
                    19999,
                    0,
                    "https://http2.mlstatic.com/D_NQ_NP_866208-MLA74951585635_032024-O.webp",
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

            /*

            //DATOS REPETIDOS

            new Product(
                Guid.NewGuid(),
                "Kit de Herramientas de Jardinería",
                "Haz que tu jardín florezca con este completo kit de herramientas de jardinería. Incluye una variedad de herramientas esenciales como palas, rastrillos, tijeras de podar y más, todo en un práctico estuche. Diseñadas para durar y facilitar el trabajo en el jardín, estas herramientas te ayudarán a mantener tu espacio verde hermoso y saludable durante todo el año.",
                2299,
                9,
                "https://http2.mlstatic.com/D_NQ_NP_845110-MLA43219745617_082020-O.webp",
                10
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
               "https://http2.mlstatic.com/D_NQ_NP_871625-MLA75823629201_042024-O.webp",
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
               "https://http2.mlstatic.com/D_NQ_NP_871625-MLA75823629201_042024-O.webpg",
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
            */
            
            );
            
        }
    }
}
