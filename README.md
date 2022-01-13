# TurnBasedRPGCase


PLAYER
•	Player’ların özellikleri (Shape, Size ve Color) scriptable object olarak oluşturulmakta ve HeroCreator objesi üzerinden atanmaktadır.  
•	Oluşturulan 10 Hero menüde gösterilmektedir. Bunlardan istenen sayıda kart (default 3 ama farklı bir değer girilebilir-HeroCreator objesinden-) seçildiğinde oyuna başlama butonu aktif olmaktadır.
•	Oyun başlatıldığında seçilen kartlar BattlePreparation scripti aracılığıyla GameObject olarak instantiate edilmektedir.

ENEMY
•	Oyundaki enemy’nin şekil özellikleri rasgele oluşturulan 10 Hero’dan birisi seçilerek verilmektedir. 
•	Enemy AP ve HP değerleri rasgele atanmaktadır. 

Shape, Size ve Color Scriptable Objects 
•	Oluşturulan SO ‘lara farklı sprite ve material atanabilir.
•	SO’lardaki seçenekler Enum’dan (Enum Holder) alınmaktadır. Buraya farklı seçenekler eklenip- azaltılabilir.

STATES
•	Oyunun genişleyebileceği düşünülerek State Pattern kullanılmaya çalışılmıştır. 

EVENTS

•	Oyundaki Event’ler takibi kolay olması için EventManager’da tutulmaktadır. 

BATTLE
•	Oyunda karakterler etkileşime girdiğinde collider’ları geçici süreliğine kapatılmakta ve bu esnada küçük bir animasyon (DOTween ile) oynatılmaktadır.
•	Oyunun kazanılması ve kaybedilmesi durumuna göre bir text ve return butonu aktif edilmektedir. 
