using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle_Script : MonoBehaviour
{

    [SerializeField] GameObject OxySource;
    [SerializeField] Sprite[] Needle_Sprites = new Sprite[0];
    [SerializeField] int oxy_input;
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //change source to get oxygen system input
        oxy_input = OxySource.GetComponent<Oxygen_Tracker_test>().oxytrack;

        //change needle postion based on remaining oxygen
        //incoming too many if statements

        if (oxy_input <= 2){
            spriteR.sprite = Needle_Sprites[62];
        }
        else if (3 <= oxy_input && oxy_input <= 5){
            spriteR.sprite = Needle_Sprites[63];
        }
        else if (6 <= oxy_input && oxy_input <= 9){
            spriteR.sprite = Needle_Sprites[64];
        }
        else if (10 <= oxy_input && oxy_input <= 12){
            spriteR.sprite = Needle_Sprites[65];
        }
        else if (13 <= oxy_input && oxy_input <= 16){
            spriteR.sprite = Needle_Sprites[66];
        }
        else if (17 <= oxy_input && oxy_input <= 19){
            spriteR.sprite = Needle_Sprites[67];
        }
        else if (20 <= oxy_input && oxy_input <= 23){
            spriteR.sprite = Needle_Sprites[68];
        }
        else if (24 <= oxy_input && oxy_input <= 26){
            spriteR.sprite = Needle_Sprites[69];
        }
        else if (27 <= oxy_input && oxy_input <= 30){
            spriteR.sprite = Needle_Sprites[70];
        }
        else if (31 <= oxy_input && oxy_input <= 33){
            spriteR.sprite = Needle_Sprites[71];
        }
        else if (34 <= oxy_input && oxy_input <= 37){
            spriteR.sprite = Needle_Sprites[72];
        }
        else if (38 <= oxy_input && oxy_input <= 40){
            spriteR.sprite = Needle_Sprites[73];
        }
        else if (41 <= oxy_input && oxy_input <= 44){
            spriteR.sprite = Needle_Sprites[74];
        }
        else if (45 <= oxy_input && oxy_input <= 47){
            spriteR.sprite = Needle_Sprites[75];
        }
        else if (48 <= oxy_input && oxy_input <= 51){
            spriteR.sprite = Needle_Sprites[76];
        }
        else if (52 <= oxy_input && oxy_input <= 54){
            spriteR.sprite = Needle_Sprites[77];
        }
        else if (55 <= oxy_input && oxy_input <= 58){
            spriteR.sprite = Needle_Sprites[78];
        }
        else if (59 <= oxy_input && oxy_input <= 61){
            spriteR.sprite = Needle_Sprites[79];
        }
        else if (62 <= oxy_input && oxy_input <= 65){
            spriteR.sprite = Needle_Sprites[80];
        }
        else if (66 <= oxy_input && oxy_input <= 68){
            spriteR.sprite = Needle_Sprites[81];
        }
        else if (69 <= oxy_input && oxy_input <= 72){
            spriteR.sprite = Needle_Sprites[82];
        }
        else if (73 <= oxy_input && oxy_input <= 75){
            spriteR.sprite = Needle_Sprites[83];
        }
        else if (76 <= oxy_input && oxy_input <= 79){
            spriteR.sprite = Needle_Sprites[84];
        }
        else if (80 <= oxy_input && oxy_input <= 82){
            spriteR.sprite = Needle_Sprites[85];
        }
        else if (83 <= oxy_input && oxy_input <= 86){
            spriteR.sprite = Needle_Sprites[86];
        }
        else if (87 <= oxy_input && oxy_input <= 89){
            spriteR.sprite = Needle_Sprites[87];
        }
        else if (90 <= oxy_input && oxy_input <= 93){
            spriteR.sprite = Needle_Sprites[88];
        }
        else if (94 <= oxy_input && oxy_input <= 96){
            spriteR.sprite = Needle_Sprites[89];
        }
        else if (97 <= oxy_input && oxy_input <= 100){
            spriteR.sprite = Needle_Sprites[90];
        }
        else if (101 <= oxy_input && oxy_input <= 103){
            spriteR.sprite = Needle_Sprites[91];
        }
        else if (104 <= oxy_input && oxy_input <= 107){
            spriteR.sprite = Needle_Sprites[92];
        }
        else if (108 <= oxy_input && oxy_input <= 110){
            spriteR.sprite = Needle_Sprites[93];
        }
        else if (111 <= oxy_input && oxy_input <= 114){
            spriteR.sprite = Needle_Sprites[94];
        }
        else if (115 <= oxy_input && oxy_input <= 117){
            spriteR.sprite = Needle_Sprites[95];
        }
        else if (118 <= oxy_input && oxy_input <= 121){
            spriteR.sprite = Needle_Sprites[96];
        }
        else if (122 <= oxy_input && oxy_input <= 124){
            spriteR.sprite = Needle_Sprites[97];
        }
        else if (125 <= oxy_input && oxy_input <= 128){
            spriteR.sprite = Needle_Sprites[98];
        }
        else if (129 <= oxy_input && oxy_input <= 131){
            spriteR.sprite = Needle_Sprites[99];
        }
        else if (132 <= oxy_input && oxy_input <= 135){
            spriteR.sprite = Needle_Sprites[100];
        }
        else if (136 <= oxy_input && oxy_input <= 138){
            spriteR.sprite = Needle_Sprites[101];
        }
        else if (139 <= oxy_input && oxy_input <= 142){
            spriteR.sprite = Needle_Sprites[102];
        }
        else if (143 <= oxy_input && oxy_input <= 147){
            spriteR.sprite = Needle_Sprites[103];
        }
        else if (148 <= oxy_input && oxy_input <= 152){
            spriteR.sprite = Needle_Sprites[0];
        }
        else if (153 <= oxy_input && oxy_input <= 157){
            spriteR.sprite = Needle_Sprites[1];
        }
        else if (158 <= oxy_input && oxy_input <= 161){
            spriteR.sprite = Needle_Sprites[2];
        }
        else if (162 <= oxy_input && oxy_input <= 164){
            spriteR.sprite = Needle_Sprites[3];
        }
        else if (165 <= oxy_input && oxy_input <= 168){
            spriteR.sprite = Needle_Sprites[4];
        }
        else if (169 <= oxy_input && oxy_input <= 171){
            spriteR.sprite = Needle_Sprites[5];
        }
        else if (172 <= oxy_input && oxy_input <= 175){
            spriteR.sprite = Needle_Sprites[6];
        }
        else if (176 <= oxy_input && oxy_input <= 178){
            spriteR.sprite = Needle_Sprites[7];
        }
        else if (179 <= oxy_input && oxy_input <= 182){
            spriteR.sprite = Needle_Sprites[8];
        }
        else if (183 <= oxy_input && oxy_input <= 185){
            spriteR.sprite = Needle_Sprites[9];
        }
        else if (186 <= oxy_input && oxy_input <= 189){
            spriteR.sprite = Needle_Sprites[10];
        }
        else if (190 <= oxy_input && oxy_input <= 192){
            spriteR.sprite = Needle_Sprites[11];
        }
        else if (193 <= oxy_input && oxy_input <= 196){
            spriteR.sprite = Needle_Sprites[12];
        }
        else if (197 <= oxy_input && oxy_input <= 199){
            spriteR.sprite = Needle_Sprites[13];
        }
        else if (200 <= oxy_input && oxy_input <= 203){
            spriteR.sprite = Needle_Sprites[14];
        }
        else if (204 <= oxy_input && oxy_input <= 206){
            spriteR.sprite = Needle_Sprites[15];
        }
        else if (207 <= oxy_input && oxy_input <= 210){
            spriteR.sprite = Needle_Sprites[16];
        }
        else if (211 <= oxy_input && oxy_input <= 213){
            spriteR.sprite = Needle_Sprites[17];
        }
        else if (214 <= oxy_input && oxy_input <= 217){
            spriteR.sprite = Needle_Sprites[18];
        }
        else if (218 <= oxy_input && oxy_input <= 220){
            spriteR.sprite = Needle_Sprites[19];
        }
        else if (221 <= oxy_input && oxy_input <= 224){
            spriteR.sprite = Needle_Sprites[20];
        }
        else if (225 <= oxy_input && oxy_input <= 227){
            spriteR.sprite = Needle_Sprites[21];
        }
        else if (228 <= oxy_input && oxy_input <= 231){
            spriteR.sprite = Needle_Sprites[22];
        }
        else if (232 <= oxy_input && oxy_input <= 234){
            spriteR.sprite = Needle_Sprites[23];
        }
        else if (235 <= oxy_input && oxy_input <= 238){
            spriteR.sprite = Needle_Sprites[24];
        }
        else if (239 <= oxy_input && oxy_input <= 241){
            spriteR.sprite = Needle_Sprites[25];
        }
        else if (242 <= oxy_input && oxy_input <= 245){
            spriteR.sprite = Needle_Sprites[26];
        }
        else if (246 <= oxy_input && oxy_input <= 248){
            spriteR.sprite = Needle_Sprites[27];
        }
        else if (249 <= oxy_input && oxy_input <= 252){
            spriteR.sprite = Needle_Sprites[28];
        }
        else if (253 <= oxy_input && oxy_input <= 255){
            spriteR.sprite = Needle_Sprites[29];
        }
        else if (256 <= oxy_input && oxy_input <= 259){
            spriteR.sprite = Needle_Sprites[30];
        }
        else if (260 <= oxy_input && oxy_input <= 262){
            spriteR.sprite = Needle_Sprites[31];
        }
        else if (263 <= oxy_input && oxy_input <= 266){
            spriteR.sprite = Needle_Sprites[32];
        }
        else if (267 <= oxy_input && oxy_input <= 269){
            spriteR.sprite = Needle_Sprites[33];
        }
        else if (270 <= oxy_input && oxy_input <= 273){
            spriteR.sprite = Needle_Sprites[34];
        }
        else if (274 <= oxy_input && oxy_input <= 276){
            spriteR.sprite = Needle_Sprites[35];
        }
        else if (277 <= oxy_input && oxy_input <= 280){
            spriteR.sprite = Needle_Sprites[36];
        }
        else if (281 <= oxy_input && oxy_input <= 283){
            spriteR.sprite = Needle_Sprites[37];
        }
        else if (284 <= oxy_input && oxy_input <= 287){
            spriteR.sprite = Needle_Sprites[38];
        }
        else if (288 <= oxy_input && oxy_input <= 290){
            spriteR.sprite = Needle_Sprites[39];
        }
        else if (291 <= oxy_input && oxy_input <= 294){
            spriteR.sprite = Needle_Sprites[40];
        }
        else if (295 <= oxy_input && oxy_input <= 297){
            spriteR.sprite = Needle_Sprites[41];
        }
        else if (298 <= oxy_input){
            spriteR.sprite = Needle_Sprites[42];
        }
    }
}
