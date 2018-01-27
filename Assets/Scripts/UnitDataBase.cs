using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "UnitDatabase")]
public class UnitDataBase : ScriptableObject {

    public Sprite[] unitSprites;
    public Sprite[] unitDeadSprites;
    public Sprite[] unitMaskSprites;
    public Sprite[] unitGasMaskSprites;
    public EnemyCarring carringThing;
}
[Serializable]
public class EnemyCarring {
    public Sprite[] unitSpritesB;
    public Sprite[] unitSpritesC;
    public Sprite[] unitSpritesD;
    public Sprite[] unitSpritesE;
    public Sprite[] unitSpritesF;
    public Sprite[] unitSpritesG;
    public Sprite[] unitSpritesH;
    public Sprite[] unitSpritesI;
    public Sprite[] unitSpritesJ;
    public Sprite[] unitSpritesK;
    public Sprite[] unitSpritesL;
    public Sprite[] unitSpritesM;
    public Sprite[] unitSpritesN;
    public Sprite[] unitSpritesO;

    public Sprite GetCarringSprite(int carrier, int body) {
        switch (carrier) {
            case 1:
                return unitSpritesB[body];
            case 2:
                return unitSpritesC[body];
            case 3:
                return unitSpritesD[body];
            case 4:
                return unitSpritesE[body];
            case 5:
                return unitSpritesF[body];
            case 6:
                return unitSpritesG[body];
            case 7:
                return unitSpritesH[body];
            case 8:
                return unitSpritesI[body];
            case 9:
                return unitSpritesJ[body];
            case 10:
                return unitSpritesK[body];
            case 11:
                return unitSpritesL[body];
            case 12:
                return unitSpritesM[body];
            case 13:
                return unitSpritesN[body];
            case 14:
                return unitSpritesO[body];
            default:
                return unitSpritesB[body];
        }
    }
}
