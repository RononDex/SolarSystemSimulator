matrix View;
matrix Projection;

float LineOffset;
float LineThickness;
float LineCount;

Texture2D SceneMap;

SamplerState TrilinearSampler
{
    Filter = MIN_MAG_MIP_LINEAR;
    AddressU = CLAMP;
    AddressV = CLAMP;
};

struct VS_INPUT
{
  float3 Position  : POSITION;
  float2 Texcoord  : TEXCOORD;
};

struct PS_INPUT
{
  float4 Position  : SV_POSITION;
  float2 Texcoord  : TEXCOORD;
  float3 Normal    : NORMAL;
  float4 Color     : COLOR;
  float3 Tangent   : TANGENT;
  float3 Bitangent : BITANGENT;
};

PS_INPUT VS_Main(VS_INPUT input)
{
  PS_INPUT output = (PS_INPUT)0;
  
  output.Position = float4(input.Position,1);
  output.Texcoord = input.Texcoord;
  
  return output;
}

float4 PS_Main(PS_INPUT input) : SV_TARGET
{
  float4 color = SceneMap.Sample(TrilinearSampler, input.Texcoord);
  if((input.Texcoord.y + LineOffset) * 256 * LineCount % 2 * LineThickness < 1 && !(color.r == 0 && color.g == 0 && color.b == 0))
  {
    color.a *= 0.7;
  }
  return color;
}

technique11 Main
{
  pass p0
  {
    SetVertexShader(CompileShader(vs_5_0, VS_Main()));
    SetHullShader(NULL);
    SetDomainShader(NULL);
    SetGeometryShader(NULL);
    SetPixelShader(CompileShader(ps_5_0, PS_Main()));
  }
};
