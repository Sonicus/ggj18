Shader "WireShader" {
    Properties {
		_Background ("Background", Color) = (0.0,0.0,0.0,0.0)
        _Wire1 ("Base (RGB)", 2D) = "white" {}
		_Wire2 ("Base (RGB)", 2D) = "white" {}
        _Alpha1 ("Alpha (A)", 2D) = "white" {}
		_Alpha2 ("Alpha (A)", 2D) = "white" {}
    }
    SubShader {
		Tags { "RenderType" = "Opaque"}
       
		ZWrite On
       
		Blend SrcColor Zero

		ColorMask RGB

        Pass {

			Color [_Background]

            SetTexture[_Wire1] {
                Combine previous + texture
            }
            SetTexture[_Alpha1] {
                Combine previous * texture
            }

			SetTexture[_Wire2] {
                Combine previous + texture
            } 
            SetTexture[_Alpha2] {
                Combine previous * texture
            }
        }
    }
}
