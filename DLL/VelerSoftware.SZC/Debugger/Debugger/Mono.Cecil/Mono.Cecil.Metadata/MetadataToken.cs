// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


namespace VelerSoftware.SZC.Debugger.Debugger.Mono.Cecil.Metadata
{
    public struct MetadataToken
    {
        uint m_rid;
        TokenType m_type;

        public uint RID
        {
            get { return m_rid; }
        }

        public TokenType TokenType
        {
            get { return m_type; }
        }

        public static readonly MetadataToken Zero = new MetadataToken((TokenType)0, 0);

        public MetadataToken(int token)
        {
            m_type = (TokenType)(token & 0xff000000);
            m_rid = (uint)token & 0x00ffffff;
        }

        public MetadataToken(TokenType table, uint rid)
        {
            m_type = table;
            m_rid = rid;
        }

        internal static MetadataToken FromMetadataRow(TokenType table, int rowIndex)
        {
            return new MetadataToken(table, (uint)rowIndex + 1);
        }

        public uint ToUInt()
        {
            return (uint)m_type | m_rid;
        }

        public override int GetHashCode()
        {
            return (int)ToUInt();
        }

        public override bool Equals(object other)
        {
            if (other is MetadataToken)
            {
                MetadataToken o = (MetadataToken)other;
                return o.m_rid == m_rid && o.m_type == m_type;
            }

            return false;
        }

        public static bool operator ==(MetadataToken one, MetadataToken other)
        {
            return one.Equals(other);
        }

        public static bool operator !=(MetadataToken one, MetadataToken other)
        {
            return !one.Equals(other);
        }

        public override string ToString()
        {
            return string.Format("{0} [0x{1}]",
                m_type, m_rid.ToString("x4"));
        }
    }
}