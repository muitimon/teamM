/*
 *
 * (C) Cyberconian Oclanay 1992-2018. All Rights Reserved.
 * 
 */
 using UnityEngine;
namespace Unity.Cyberconian.Oclanay.BasicSevenSegmentDisplay {    
    public class BasicSevenSegmentDisplay : MonoBehaviour {        
        public char Input;        
        public GameObject Display;
        public Color ActiveColor = new Color(1, 0, 0, 1);
		public Color PassiveColor = new Color(0.01f, 0, 0, 1);
		public Color FaceColor = new Color(0.001f, 0.001f, 0.001f, 1);
        public bool Tail6 = false;
        public bool Tail7 = false;
        public bool Tail9 = false;               
        public bool UseDot = false;
        private const int SEGMENTS = 8;
        private char _Input;
        private void Start() { 
            this._Input = this.Input;            
            this.SetData(this._Input);
        }
        public void ClearDisplay() {
            this._Input = ' ';
            this.Input = ' ';
            this.UseDot = false;
            this.RenderDisplay(this._Input);
        }    
        public void SetData(int c) {
            string tmp = c.ToString();
            char cc = tmp[0];
            this._Input = cc;
            this.Input = cc;
            this.RenderDisplay(this._Input);
        }
        public void SetData(char c) {
            this._Input = c;
            this.Input = c;
            this.RenderDisplay(this._Input);
        }
        public void SetDot(bool active) {
            this.UseDot = active;
            this.RenderDisplay(this._Input);
        }
        public void SetActiveLEDColor(Color c) {
            this.ActiveColor = c;
            this.RenderDisplay(this._Input);
        }
        public void SetPassiveLEDColor(Color c) {
            this.PassiveColor = c;
            this.RenderDisplay(this._Input);
        }
        public void SetFaceColor(Color c) {
            GameObject g = this.Display.transform.GetChild(0).gameObject;
            Renderer r = g.GetComponent<Renderer>();
            Material m = r.material;     
			m.color = this.FaceColor;      
            m.DisableKeyword("_EMISSION");  
        } 
        protected virtual void RenderDisplay(char c) { 
            int x = this.Convert(c, this.Tail6, this.Tail7, this.Tail9);
            if(this.UseDot) x += 128;
            for (int j = 0; j < SEGMENTS; j++) {
                GameObject g = this.Display.transform.GetChild(1).transform.GetChild(j).gameObject;
                Renderer r = g.GetComponent<Renderer>();
                Material m = r.material;     
                if((x >> j & 1) == 1) {                   
                    m.EnableKeyword("_EMISSION"); 
					m.SetColor("_EmissionColor", this.ActiveColor);
				} else {
					m.color = this.PassiveColor;      
                    m.DisableKeyword("_EMISSION"); 
                } 
            }
        }
        protected virtual int Convert(char c, bool tail6, bool tail7, bool tail9) {         
			int z = -1;
			switch(c) { 
			    case '0': z = 63; break;  
			    case '1': z = 6; break; 
			    case '2': z = 91; break; 
			    case '3': z = 79; break;
			    case '4': z = 102; break;
			    case '5': z = 109; break;
			    case '6': z = tail6 ? 125 : 124; break;
			    case '7': z = tail7 ? 39 : 7; break;
			    case '8': z = 127; break;
			    case '9': z = tail9 ? 111 : 103; break;
			    case 'A': z = 119; break;
			    case 'B': z = 125; break;
			    case 'C': z = 57; break;
			    case 'D': z = 94; break;
			    case 'E': z = 121; break;
			    case 'F': z = 113; break;
			    case '-': z = 64; break;		
			    case '.': z = 128; break;		
			    default:  z = 0; break;
			}
			return z;
		}      
    }
}