using Chroma.Natives.Bindings.SDL;

namespace Chroma.Graphics.Accelerated
{
    public enum ShaderLanguage
    {
        None = SDL_gpu.GPU_ShaderLanguageEnum.GPU_LANGUAGE_NONE,
        ArbAssembly = SDL_gpu.GPU_ShaderLanguageEnum.GPU_LANGUAGE_ARB_ASSEMBLY,
        GLSL = SDL_gpu.GPU_ShaderLanguageEnum.GPU_LANGUAGE_GLSL,
        GLSLES = SDL_gpu.GPU_ShaderLanguageEnum.GPU_LANGUAGE_GLSLES,
        HLSL = SDL_gpu.GPU_ShaderLanguageEnum.GPU_LANGUAGE_HLSL,
        CG = SDL_gpu.GPU_ShaderLanguageEnum.GPU_LANGUAGE_CG
    }
}