#version 310 es
precision mediump float;

in vec3 cr_VertexPosition;
in vec4 cr_VertexColor;
in vec2 cr_TexCoord;

uniform vec4 tri_color;

out vec4 out_color;

void main(void) {
    out_color = tri_color;
}
