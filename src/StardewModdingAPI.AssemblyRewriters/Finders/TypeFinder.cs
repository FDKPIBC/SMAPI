using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace StardewModdingAPI.AssemblyRewriters.Finders
{
    /// <summary>Finds CIL instructions that reference a given type.</summary>
    public class TypeFinder : IInstructionFinder
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The full type name for which to find references.</summary>
        private readonly string FullTypeName;


        /*********
        ** Accessors
        *********/
        /// <summary>A brief noun phrase indicating what the instruction finder matches.</summary>
        public string NounPhrase { get; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="fullTypeName">The full type name to match.</param>
        /// <param name="nounPhrase">A brief noun phrase indicating what the instruction finder matches (or <c>null</c> to generate one).</param>
        public TypeFinder(string fullTypeName, string nounPhrase = null)
        {
            this.FullTypeName = fullTypeName;
            this.NounPhrase = nounPhrase ?? $"{fullTypeName} type";
        }

        /// <summary>Get whether a CIL instruction matches.</summary>
        /// <param name="instruction">The IL instruction.</param>
        /// <param name="platformChanged">Whether the mod was compiled on a different platform.</param>
        public bool IsMatch(Instruction instruction, bool platformChanged)
        {
            string fullName = this.FullTypeName;

            // field reference
            FieldReference fieldRef = RewriteHelper.AsFieldReference(instruction);
            if (fieldRef != null)
            {
                return
                    fieldRef.DeclaringType.FullName == fullName // field on target class
                    || fieldRef.FieldType.FullName == fullName; // field value is target class
            }

            // method reference
            MethodReference methodRef = RewriteHelper.AsMethodReference(instruction);
            if (methodRef != null)
            {
                return
                    methodRef.DeclaringType.FullName == fullName // method on target class
                    || methodRef.ReturnType.FullName == fullName // method returns target class
                    || methodRef.Parameters.Any(p => p.ParameterType.FullName == fullName); // method parameters
            }

            return false;
        }
    }
}
