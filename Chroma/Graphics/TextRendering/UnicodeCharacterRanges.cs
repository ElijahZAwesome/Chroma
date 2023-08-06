using System;

namespace Chroma.Graphics.TextRendering
{
    public class UnicodeCharacterRanges
    {
        public static readonly Range BasicLatin = new(0x0020, 0x007F);
        public static readonly Range Latin1Supplement = new(0x00A0, 0x00FF);
        public static readonly Range LatinExtendedA = new(0x0100, 0x017F);
        public static readonly Range LatinExtendedB = new(0x0180, 0x024F);
        public static readonly Range IpaExtensions = new(0x0250, 0x02AF);
        public static readonly Range SpacingModifierLetters = new(0x02B0, 0x02FF);
        public static readonly Range CombiningDiacriticalMarks = new(0x0300, 0x036F);
        public static readonly Range Greek = new(0x0370, 0x03FF);
        public static readonly Range Cyrillic = new(0x0400, 0x04FF);
        public static readonly Range CyrillicSupplement = new(0x0500, 0x052F);
        public static readonly Range Armenian = new(0x0530, 0x058F);
        public static readonly Range Hebrew = new(0x0590, 0x05FF);
        public static readonly Range Arabic = new(0x0600, 0x06FF);
        public static readonly Range Syriac = new(0x0700, 0x074F);
        public static readonly Range Thaana = new(0x0780, 0x07BF);
        public static readonly Range Devanagari = new(0x0900, 0x097F);
        public static readonly Range Bengali = new(0x0980, 0x09FF);
        public static readonly Range Gurmukhi = new(0x0A00, 0x0A7F);
        public static readonly Range Gujarati = new(0x0A80, 0x0AFF);
        public static readonly Range Oriya = new(0x0B00, 0x0B7F);
        public static readonly Range Tamil = new(0x0B80, 0x0BFF);
        public static readonly Range Telugu = new(0x0C00, 0x0C7F);
        public static readonly Range Kannada = new(0x0C80, 0x0CFF);
        public static readonly Range Malayalam = new(0x0D00, 0x0D7F);
        public static readonly Range Sinhala = new(0x0D80, 0x0DFF);
        public static readonly Range Thai = new(0x0E00, 0x0E7F);
        public static readonly Range Lao = new(0x0E80, 0x0EFF);
        public static readonly Range Tibetan = new(0x0F00, 0x0FFF);
        public static readonly Range Myanmar = new(0x1000, 0x109F);
        public static readonly Range Georgian = new(0x10A0, 0x10FF);
        public static readonly Range HangulJamo = new(0x1100, 0x11FF);
        public static readonly Range Ethiopic = new(0x1200, 0x137F);
        public static readonly Range Cherokee = new(0x13A0, 0x13FF);
        public static readonly Range UnifiedCanadianAboriginalSyllabics = new(0x1400, 0x167F);
        public static readonly Range Ogham = new(0x1680, 0x169F);
        public static readonly Range Runic = new(0x16A0, 0x16FF);
        public static readonly Range Tagalog = new(0x1700, 0x171F);
        public static readonly Range Hanunoo = new(0x1720, 0x173F);
        public static readonly Range Buhid = new(0x1740, 0x175F);
        public static readonly Range Tagbanwa = new(0x1760, 0x177F);
        public static readonly Range Khmer = new(0x1780, 0x17FF);
        public static readonly Range Mongolian = new(0x1800, 0x18AF);
        public static readonly Range Limbu = new(0x1900, 0x194F);
        public static readonly Range TaiLe = new(0x1950, 0x197F);
        public static readonly Range KhmerSymbols = new(0x19E0, 0x19FF);
        public static readonly Range PhoneticExtensions = new(0x1D00, 0x1D7F);
        public static readonly Range LatinExtendedAdditional = new(0x1E00, 0x1EFF);
        public static readonly Range GreekExtended = new(0x1F00, 0x1FFF);
        public static readonly Range GeneralPunctuation = new(0x2000, 0x206F);
        public static readonly Range SuperscriptsAndSubscripts = new(0x2070, 0x209F);
        public static readonly Range CurrencySymbols = new(0x20A0, 0x20CF);
        public static readonly Range CombiningDiacriticalMarksForSymbols = new(0x20D0, 0x20FF);
        public static readonly Range LetterlikeSymbols = new(0x2100, 0x214F);
        public static readonly Range NumberForms = new(0x2150, 0x218F);
        public static readonly Range Arrows = new(0x2190, 0x21FF);
        public static readonly Range MathematicalOperators = new(0x2200, 0x22FF);
        public static readonly Range MiscellaneousTechnical = new(0x2300, 0x23FF);
        public static readonly Range ControlPictures = new(0x2400, 0x243F);
        public static readonly Range OpticalCharacterRecognition = new(0x2440, 0x245F);
        public static readonly Range EnclosedAlphanumerics = new(0x2460, 0x24FF);
        public static readonly Range BoxDrawing = new(0x2500, 0x257F);
        public static readonly Range BlockElements = new(0x2580, 0x259F);
        public static readonly Range GeometricShapes = new(0x25A0, 0x25FF);
        public static readonly Range MiscellaneousSymbols = new(0x2600, 0x26FF);
        public static readonly Range Dingbats = new(0x2700, 0x27BF);
        public static readonly Range MiscellaneousMathematicalSymbolsA = new(0x27C0, 0x27EF);
        public static readonly Range SupplementalArrowsA = new(0x27F0, 0x27FF);
        public static readonly Range BraillePatterns = new(0x2800, 0x28FF);
        public static readonly Range SupplementalArrowsB = new(0x2900, 0x297F);
        public static readonly Range MiscellaneousMathematicalSymbolsB = new(0x2980, 0x29FF);
        public static readonly Range SupplementalMathematicalOperators = new(0x2A00, 0x2AFF);
        public static readonly Range MiscellaneousSymbolsAndArrows = new(0x2B00, 0x2BFF);
        public static readonly Range CjkRadicalsSupplement = new(0x2E80, 0x2EFF);
        public static readonly Range KangxiRadicals = new(0x2F00, 0x2FDF);
        public static readonly Range IdeographicDescriptionCharacters = new(0x2FF0, 0x2FFF);
        public static readonly Range CjkSymbolsAndPunctuation = new(0x3000, 0x303F);
        public static readonly Range Hiragana = new(0x3040, 0x309F);
        public static readonly Range Katakana = new(0x30A0, 0x30FF);
        public static readonly Range Bopomofo = new(0x3100, 0x312F);
        public static readonly Range HangulCompatibilityJamo = new(0x3130, 0x318F);
        public static readonly Range Kanbun = new(0x3190, 0x319F);
        public static readonly Range BopomofoExtended = new(0x31A0, 0x31BF);
        public static readonly Range KatakanaPhoneticExtensions = new(0x31F0, 0x31FF);
        public static readonly Range EnclosedCjkLettersAndMonths = new(0x3200, 0x32FF);
        public static readonly Range CjkCompatibility = new(0x3300, 0x33FF);
        public static readonly Range CjkUnifiedIdeographcsExtensionA = new(0x3400, 0x4DBF);
        public static readonly Range YijingHexagramSymbols = new(0x4DC0, 0x4DFF);
        public static readonly Range CjkUnifiedIdeographs = new(0x4E00, 0x9FFF);
        public static readonly Range HangulSyllables = new(0xAC00, 0xD7AF);
    }
}