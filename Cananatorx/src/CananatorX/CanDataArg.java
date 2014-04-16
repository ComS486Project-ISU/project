/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package CananatorX;
import java.util.EventObject;
/**
 *
 * @author prisum
 */
public class CanDataArg extends EventObject
{
    private PrisumSolarCarState state;
    private Object tag;
    private PrisumCanDataType type;
    
    CanDataArg(Object source, PrisumSolarCarState state, Object tag, PrisumCanDataType type)
    {
        super(source);
        this.state = state;
        this.tag = tag;
        this.type = type;
    }
    
    //accessors
    public PrisumCanDataType GetArgType()
    {
        return type;
    }

    public PrisumSolarCarState GetState()
    {
        return state;
    }
    
    Object GetTag()
    {
        //string 0
        return tag;
    }

    public enum PrisumCanDataType
    {
        /**
        * tag is string status
        */
        CanStatus,
        
        /**
         * tag is integer array for a can message
         */
        NewCanMessage,
        
        /**
         * tag is string of module id
         */
        BattTempReadError,
        
        /**
         * tag is battery module obj
         */
        BatteryModule,
        //etc
        
        /**
         * tag is BPS obj
         */
        BatteryProtectionSystem,
        
        /**
         * tag is Motor obj
         */
        Motor;
    }

}