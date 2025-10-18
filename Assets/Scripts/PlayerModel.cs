using Metal.Player;
using Unity.VisualScripting;

namespace Metal
{
    public class PlayerModel
    {
        //simdi oyundaki playerlari eklemek ya da bir yerden cagirabiliyor olmak laizm bu modelde
        private PlayerData _player; //private oldugu icin sadece bu classta degistirilebilir
        //bu sayede artik bi oyuncu datasi ornegi olusturduk
         public PlayerData Player => _player;// _player private oldugundan okunamaz. ama bu public deger ile okunabilir kildik. yine degistirilemez ama.

         public void SetPlayer(PlayerData data)
         {
             _player = data;
         }

         public void SetIsAttacking(bool isAttacking)
         {
             // (*) ile isaretledigim yerde eger oyuncunun attack state degismemisse bir daha set edilmesine gerek yoktur
             if (_player.IsAttacking == isAttacking) return;
             
             _player.IsAttacking = isAttacking;//  (*)  acemi birisi bunu yazarak direkt cikabilir
             
         }
    }
}