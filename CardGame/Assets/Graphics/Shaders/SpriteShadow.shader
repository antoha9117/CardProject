Shader "Sprites/Shadow/Diffuse"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
				_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
	}

		SubShader
		{
			Tags
			{
				"Queue" = "Transparent"
				"IgnoreProjector" = "True"
				"RenderType" = "Transparent"
				"PreviewType" = "Plane"
				"CanUseSpriteAtlas" = "True"
			}

			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

				#pragma surface surf Lambert alpha:fade vertex:vert
				#pragma multi_compile DUMMY PIXELSNAP_ON

							sampler2D _MainTex;
							fixed4 _Color;

							struct Input
							{
									float2 uv_MainTex;
									fixed4 color : COLOR;
							};

							void vert(inout appdata_full v, out Input o)
							{
									UNITY_INITIALIZE_OUTPUT(Input, o);
							}

							void surf(Input IN, inout SurfaceOutput o)
							{
									fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.color;
									o.Albedo = c.rgb;
									o.Alpha = c.a;
							}

			ENDCG
		}

			Fallback "Transparent/Cutout/Diffuse"
}
