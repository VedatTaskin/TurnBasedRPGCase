# TurnBasedRPGCase


PLAYER <br>
•	Player’ların özellikleri (Shape, Size ve Color) scriptable object olarak oluşturulmakta ve HeroCreator objesi üzerinden atanmaktadır. <br>
•	Oluşturulan 10 Hero menüde gösterilmektedir. Bunlardan istenen sayıda kart (default 3 ama farklı bir değer girilebilir-HeroCreator objesinden-) seçildiğinde oyuna başlama butonu aktif olmaktadır.<br>
•	Oyun başlatıldığında seçilen kartlar BattlePreparation scripti aracılığıyla GameObject olarak instantiate edilmektedir.<br>

ENEMY<br>
•	Oyundaki enemy’nin şekil özellikleri (renk ayrıca random) rasgele oluşturulan 10 Hero’dan birisi seçilerek verilmektedir.<br> 
•	Enemy AP ve HP değerleri rasgele atanmaktadır. <br>

SHAPE, SIZE VE COLOR SCRIPTABLE OBJECTS <br>
•	Oluşturulan SO ‘lara farklı sprite ve material atanabilir.<br>
•	SO’lardaki seçenekler Enum’dan (Enum Holder) alınmaktadır. Buraya farklı seçenekler eklenip- azaltılabilir.<br>

STATES<br>
•	Oyunun genişleyebileceği düşünülerek State Pattern kullanılmaya çalışılmıştır. <br>

EVENTS<br>
•	Oyundaki Event’ler takibi kolay olması için EventManager’da tutulmaktadır. <br>

BATTLE<br>
•	Oyunda karakterler etkileşime girdiğinde collider’ları geçici süreliğine kapatılmakta ve bu esnada küçük bir animasyon (DOTween ile) oynatılmaktadır.<br>
•	Oyunun kazanılması ve kaybedilmesi durumuna göre bir text ve return butonu aktif edilmektedir. <br>
