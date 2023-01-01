#version 310 es
precision mediump float;

out vec4 _FragColor;

uniform sampler2D cr_Screen;

in vec3 cr_VertexPosition;
in vec4 cr_VertexColor;
in vec2 cr_TexCoord;
in vec2 cr_ScreenSize;
in float cr_Time;

vec4 effect(in vec4 pixel, in vec2 tex_coords)
{
    return vec4(1.0,1.0,1.01,.0);
}

void main(void) {
    _FragColor = effect(
        texture(cr_Screen, cr_TexCoord),
        cr_TexCoord
    );
}