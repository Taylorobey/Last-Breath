using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Needle_Script : MonoBehaviour
{

    [SerializeField] GameObject OxySource;
    [SerializeField] Sprite[] Needle_Sprites = new Sprite[0];
    [SerializeField] int oxy_input;
    private Image Image { get; set; }

    void Start()
    {
        Image = GetComponent<Image>();
        OxygenSystem.OnConsumeOxygenInSeconds += TickTime;
    }

    private void OnDestroy()
    {
        OxygenSystem.OnConsumeOxygenInSeconds -= TickTime;
    }

    private void TickTime(int seconds)
    {
        if (seconds <= 2){
            Image.sprite = Needle_Sprites[62];
        }
        else if (3 <= seconds && seconds <= 5){
            Image.sprite = Needle_Sprites[63];
        }
        else if (6 <= seconds && seconds <= 9){
            Image.sprite = Needle_Sprites[64];
        }
        else if (10 <= seconds && seconds <= 12){
            Image.sprite = Needle_Sprites[65];
        }
        else if (13 <= seconds && seconds <= 16){
            Image.sprite = Needle_Sprites[66];
        }
        else if (17 <= seconds && seconds <= 19){
            Image.sprite = Needle_Sprites[67];
        }
        else if (20 <= seconds && seconds <= 23){
            Image.sprite = Needle_Sprites[68];
        }
        else if (24 <= seconds && seconds <= 26){
            Image.sprite = Needle_Sprites[69];
        }
        else if (27 <= seconds && seconds <= 30){
            Image.sprite = Needle_Sprites[70];
        }
        else if (31 <= seconds && seconds <= 33){
            Image.sprite = Needle_Sprites[71];
        }
        else if (34 <= seconds && seconds <= 37){
            Image.sprite = Needle_Sprites[72];
        }
        else if (38 <= seconds && seconds <= 40){
            Image.sprite = Needle_Sprites[73];
        }
        else if (41 <= seconds && seconds <= 44){
            Image.sprite = Needle_Sprites[74];
        }
        else if (45 <= seconds && seconds <= 47){
            Image.sprite = Needle_Sprites[75];
        }
        else if (48 <= seconds && seconds <= 51){
            Image.sprite = Needle_Sprites[76];
        }
        else if (52 <= seconds && seconds <= 54){
            Image.sprite = Needle_Sprites[77];
        }
        else if (55 <= seconds && seconds <= 58){
            Image.sprite = Needle_Sprites[78];
        }
        else if (59 <= seconds && seconds <= 61){
            Image.sprite = Needle_Sprites[79];
        }
        else if (62 <= seconds && seconds <= 65){
            Image.sprite = Needle_Sprites[80];
        }
        else if (66 <= seconds && seconds <= 68){
            Image.sprite = Needle_Sprites[81];
        }
        else if (69 <= seconds && seconds <= 72){
            Image.sprite = Needle_Sprites[82];
        }
        else if (73 <= seconds && seconds <= 75){
            Image.sprite = Needle_Sprites[83];
        }
        else if (76 <= seconds && seconds <= 79){
            Image.sprite = Needle_Sprites[84];
        }
        else if (80 <= seconds && seconds <= 82){
            Image.sprite = Needle_Sprites[85];
        }
        else if (83 <= seconds && seconds <= 86){
            Image.sprite = Needle_Sprites[86];
        }
        else if (87 <= seconds && seconds <= 89){
            Image.sprite = Needle_Sprites[87];
        }
        else if (90 <= seconds && seconds <= 93){
            Image.sprite = Needle_Sprites[88];
        }
        else if (94 <= seconds && seconds <= 96){
            Image.sprite = Needle_Sprites[89];
        }
        else if (97 <= seconds && seconds <= 100){
            Image.sprite = Needle_Sprites[90];
        }
        else if (101 <= seconds && seconds <= 103){
            Image.sprite = Needle_Sprites[91];
        }
        else if (104 <= seconds && seconds <= 107){
            Image.sprite = Needle_Sprites[92];
        }
        else if (108 <= seconds && seconds <= 110){
            Image.sprite = Needle_Sprites[93];
        }
        else if (111 <= seconds && seconds <= 114){
            Image.sprite = Needle_Sprites[94];
        }
        else if (115 <= seconds && seconds <= 117){
            Image.sprite = Needle_Sprites[95];
        }
        else if (118 <= seconds && seconds <= 121){
            Image.sprite = Needle_Sprites[96];
        }
        else if (122 <= seconds && seconds <= 124){
            Image.sprite = Needle_Sprites[97];
        }
        else if (125 <= seconds && seconds <= 128){
            Image.sprite = Needle_Sprites[98];
        }
        else if (129 <= seconds && seconds <= 131){
            Image.sprite = Needle_Sprites[99];
        }
        else if (132 <= seconds && seconds <= 135){
            Image.sprite = Needle_Sprites[100];
        }
        else if (136 <= seconds && seconds <= 138){
            Image.sprite = Needle_Sprites[101];
        }
        else if (139 <= seconds && seconds <= 142){
            Image.sprite = Needle_Sprites[102];
        }
        else if (143 <= seconds && seconds <= 147){
            Image.sprite = Needle_Sprites[103];
        }
        else if (148 <= seconds && seconds <= 152){
            Image.sprite = Needle_Sprites[0];
        }
        else if (153 <= seconds && seconds <= 157){
            Image.sprite = Needle_Sprites[1];
        }
        else if (158 <= seconds && seconds <= 161){
            Image.sprite = Needle_Sprites[2];
        }
        else if (162 <= seconds && seconds <= 164){
            Image.sprite = Needle_Sprites[3];
        }
        else if (165 <= seconds && seconds <= 168){
            Image.sprite = Needle_Sprites[4];
        }
        else if (169 <= seconds && seconds <= 171){
            Image.sprite = Needle_Sprites[5];
        }
        else if (172 <= seconds && seconds <= 175){
            Image.sprite = Needle_Sprites[6];
        }
        else if (176 <= seconds && seconds <= 178){
            Image.sprite = Needle_Sprites[7];
        }
        else if (179 <= seconds && seconds <= 182){
            Image.sprite = Needle_Sprites[8];
        }
        else if (183 <= seconds && seconds <= 185){
            Image.sprite = Needle_Sprites[9];
        }
        else if (186 <= seconds && seconds <= 189){
            Image.sprite = Needle_Sprites[10];
        }
        else if (190 <= seconds && seconds <= 192){
            Image.sprite = Needle_Sprites[11];
        }
        else if (193 <= seconds && seconds <= 196){
            Image.sprite = Needle_Sprites[12];
        }
        else if (197 <= seconds && seconds <= 199){
            Image.sprite = Needle_Sprites[13];
        }
        else if (200 <= seconds && seconds <= 203){
            Image.sprite = Needle_Sprites[14];
        }
        else if (204 <= seconds && seconds <= 206){
            Image.sprite = Needle_Sprites[15];
        }
        else if (207 <= seconds && seconds <= 210){
            Image.sprite = Needle_Sprites[16];
        }
        else if (211 <= seconds && seconds <= 213){
            Image.sprite = Needle_Sprites[17];
        }
        else if (214 <= seconds && seconds <= 217){
            Image.sprite = Needle_Sprites[18];
        }
        else if (218 <= seconds && seconds <= 220){
            Image.sprite = Needle_Sprites[19];
        }
        else if (221 <= seconds && seconds <= 224){
            Image.sprite = Needle_Sprites[20];
        }
        else if (225 <= seconds && seconds <= 227){
            Image.sprite = Needle_Sprites[21];
        }
        else if (228 <= seconds && seconds <= 231){
            Image.sprite = Needle_Sprites[22];
        }
        else if (232 <= seconds && seconds <= 234){
            Image.sprite = Needle_Sprites[23];
        }
        else if (235 <= seconds && seconds <= 238){
            Image.sprite = Needle_Sprites[24];
        }
        else if (239 <= seconds && seconds <= 241){
            Image.sprite = Needle_Sprites[25];
        }
        else if (242 <= seconds && seconds <= 245){
            Image.sprite = Needle_Sprites[26];
        }
        else if (246 <= seconds && seconds <= 248){
            Image.sprite = Needle_Sprites[27];
        }
        else if (249 <= seconds && seconds <= 252){
            Image.sprite = Needle_Sprites[28];
        }
        else if (253 <= seconds && seconds <= 255){
            Image.sprite = Needle_Sprites[29];
        }
        else if (256 <= seconds && seconds <= 259){
            Image.sprite = Needle_Sprites[30];
        }
        else if (260 <= seconds && seconds <= 262){
            Image.sprite = Needle_Sprites[31];
        }
        else if (263 <= seconds && seconds <= 266){
            Image.sprite = Needle_Sprites[32];
        }
        else if (267 <= seconds && seconds <= 269){
            Image.sprite = Needle_Sprites[33];
        }
        else if (270 <= seconds && seconds <= 273){
            Image.sprite = Needle_Sprites[34];
        }
        else if (274 <= seconds && seconds <= 276){
            Image.sprite = Needle_Sprites[35];
        }
        else if (277 <= seconds && seconds <= 280){
            Image.sprite = Needle_Sprites[36];
        }
        else if (281 <= seconds && seconds <= 283){
            Image.sprite = Needle_Sprites[37];
        }
        else if (284 <= seconds && seconds <= 287){
            Image.sprite = Needle_Sprites[38];
        }
        else if (288 <= seconds && seconds <= 290){
            Image.sprite = Needle_Sprites[39];
        }
        else if (291 <= seconds && seconds <= 294){
            Image.sprite = Needle_Sprites[40];
        }
        else if (295 <= seconds && seconds <= 297){
            Image.sprite = Needle_Sprites[41];
        }
        else if (298 <= seconds){
            Image.sprite = Needle_Sprites[42];
        }
    }
}
